package main

import "chat/server"

func main() {
	server := server.NewServer(":3000")
	server.Start()
}
