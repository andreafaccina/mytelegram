﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/inputPeerUserFromMessage" />
///</summary>
[TlObject(0xa87b0a1c)]
public sealed class TInputPeerUserFromMessage : IInputPeer
{
    public uint ConstructorId => 0xa87b0a1c;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer Peer { get; set; }
    public int MsgId { get; set; }
    public long UserId { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Peer.Serialize(bw);
        bw.Write(MsgId);
        bw.Write(UserId);
    }

    public void Deserialize(BinaryReader br)
    {
        Peer = br.Deserialize<MyTelegram.Schema.IInputPeer>();
        MsgId = br.ReadInt32();
        UserId = br.ReadInt64();
    }
}