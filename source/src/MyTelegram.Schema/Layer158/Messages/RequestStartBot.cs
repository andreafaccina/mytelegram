﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
///See <a href="https://core.telegram.org/method/messages.startBot" />
///</summary>
[TlObject(0xe6df7378)]
public sealed class RequestStartBot : IRequest<MyTelegram.Schema.IUpdates>
{
    public uint ConstructorId => 0xe6df7378;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser Bot { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer Peer { get; set; }
    public long RandomId { get; set; }
    public string StartParam { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Bot.Serialize(bw);
        Peer.Serialize(bw);
        bw.Write(RandomId);
        bw.Serialize(StartParam);
    }

    public void Deserialize(BinaryReader br)
    {
        Bot = br.Deserialize<MyTelegram.Schema.IInputUser>();
        Peer = br.Deserialize<MyTelegram.Schema.IInputPeer>();
        RandomId = br.ReadInt64();
        StartParam = br.Deserialize<string>();
    }
}
