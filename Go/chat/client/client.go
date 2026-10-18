package client

import (
	"bufio"
	"crypto/aes"
	"crypto/cipher"
	"crypto/ecdh"
	"crypto/rand"
	"crypto/sha256"
	"fmt"
	"io"
	"log"
	"net"
	"os"
)

type CryptoKeys struct {
	PublicECDHKey  []byte
	PrivateECDHKey []byte
	AESKey         []byte
}

type P2PKeys struct {
	SecretECDH []byte
	AES        []byte
}

const (
	TypeAuth        = "AUTH"
	TypePeerList    = "PEER_LIST"
	TypeNewPeer     = "NEW_PEER"
	TypeGetPeerList = "GET_PEER_LIST"
	TypeSenderKey   = "SENDER_KEY"
	TypeChatMsg     = "CHAT_MSG"
)

type Message struct {
	Author string `json:"author"`
	Text   string `json:"text"`
}

type PeerInfo struct {
	Nickname  string `json:"nickname"`
	PublicKey []byte `json:"public_key"`
}

type ClientChat struct {
	Address       string
	Conn          net.Conn
	Keys          CryptoKeys
	TopologyTable map[string]P2PKeys
}

func NewClientChat(Address string) *ClientChat {
	return &ClientChat{
		Address: Address,
	}
}

func GenerateECDHSecret(privateKey []byte, publicKey []byte) []byte {
	curve := ecdh.X25519()

	myPrivateKey, _ := curve.NewPrivateKey(privateKey)
	peerPublicKey, _ := curve.NewPublicKey(publicKey)

	sharedSecret, _ := myPrivateKey.ECDH(peerPublicKey)
	aesKey := sha256.Sum256(sharedSecret)

	return aesKey[:]
}

func EncryptAESKey(secretShared []byte, aesKey []byte) []byte {
	block, _ := aes.NewCipher(secretShared)
	aesGCM, _ := cipher.NewGCM(block)

	nonce := make([]byte, aesGCM.NonceSize())
	io.ReadFull(rand.Reader, nonce)
	cipherText := aesGCM.Seal(nonce, nonce, aesKey, nil)

	return cipherText
}

func DecryptSenderKey(secretShared []byte, cipherTextWithNonce []byte) ([]byte, error) {
	block, _ := aes.NewCipher(secretShared)
	aesGCM, _ := cipher.NewGCM(block)

	nonceSize := aesGCM.NonceSize()
	if len(cipherTextWithNonce) < nonceSize {
		return nil, fmt.Errorf("cipherText too short")
	}

	nonce := cipherTextWithNonce[:nonceSize]
	actualCipherText := cipherTextWithNonce[nonceSize:]

	aesKey, err := aesGCM.Open(nil, nonce, actualCipherText, nil)
	if err != nil {
		return nil, fmt.Errorf("failed to decrypt or authenticate: %w", err)
	}

	return aesKey, nil
}

func EncryptMessage(key []byte, plainText []byte) ([]byte, error) {
	block, err := aes.NewCipher(key)
	if err != nil {
		return nil, fmt.Errorf("failed to create cipher: %w", err)
	}

	aesGCM, err := cipher.NewGCM(block)
	if err != nil {
		return nil, fmt.Errorf("failed to create gcm: %w", err)
	}

	nonce := make([]byte, aesGCM.NonceSize())
	if _, err = io.ReadFull(rand.Reader, nonce); err != nil {
		return nil, fmt.Errorf("failed to generate nonce: %w", err)
	}

	cipherText := aesGCM.Seal(nonce, nonce, plainText, nil)

	return cipherText, nil
}

func DecryptMessage(key []byte, cipherTextWithNonce []byte) ([]byte, error) {
	block, err := aes.NewCipher(key)
	if err != nil {
		return nil, fmt.Errorf("failed to create cipher: %w", err)
	}

	aesGCM, err := cipher.NewGCM(block)
	if err != nil {
		return nil, fmt.Errorf("failed to create gcm: %w", err)
	}

	nonceSize := aesGCM.NonceSize()
	if len(cipherTextWithNonce) < nonceSize {
		return nil, fmt.Errorf("cipherText too short")
	}

	nonce := cipherTextWithNonce[:nonceSize]
	actualCipherText := cipherTextWithNonce[nonceSize:]

	plaintext, err := aesGCM.Open(nil, nonce, actualCipherText, nil)
	if err != nil {
		return nil, fmt.Errorf("failed to decrypt (fake tag or wrong key): %w", err)
	}

	return plaintext, nil
}

func (c *ClientChat) Start() error {
	var err error

	c.Conn, err = net.Dial("tcp", c.Address)
	if err != nil {
		log.Fatal("Failed connection: %w", err)
	}
	defer c.Conn.Close()

	c.enterToChat()
	go c.readLoop()

	scanner := bufio.NewScanner(os.Stdin)
	for scanner.Scan() {
		text := scanner.Text()
		if text == "" {
			continue
		}
	}

	if err := scanner.Err(); err != nil {
		log.Printf("Failed read from console: %v", err)
	}
}
