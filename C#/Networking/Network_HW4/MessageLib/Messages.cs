using System;

namespace MessageLib
{
    public enum MessageType : int
    {
        SetNickname = 0x00017,
        SetDefaultName = 0x00014,
        SendingList = 0x0001C,
        SendMessageToUser = 0x0001E,
        SendingMessage = 0x00042,
        ConnectedNewUser = 0x0001a,
        UserDisconnected = 0x0001b
    }
}
