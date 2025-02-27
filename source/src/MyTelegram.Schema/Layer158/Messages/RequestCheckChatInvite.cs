﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
///See <a href="https://core.telegram.org/method/messages.checkChatInvite" />
///</summary>
[TlObject(0x3eadb1bb)]
public sealed class RequestCheckChatInvite : IRequest<MyTelegram.Schema.IChatInvite>
{
    public uint ConstructorId => 0x3eadb1bb;
    public string Hash { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Hash);
    }

    public void Deserialize(BinaryReader br)
    {
        Hash = br.Deserialize<string>();
    }
}
