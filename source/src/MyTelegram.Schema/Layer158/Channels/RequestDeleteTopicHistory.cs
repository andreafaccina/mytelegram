﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
///See <a href="https://core.telegram.org/method/channels.deleteTopicHistory" />
///</summary>
[TlObject(0x34435f2d)]
public sealed class RequestDeleteTopicHistory : IRequest<MyTelegram.Schema.Messages.IAffectedHistory>
{
    public uint ConstructorId => 0x34435f2d;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputChannel" />
    ///</summary>
    public MyTelegram.Schema.IInputChannel Channel { get; set; }
    public int TopMsgId { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Channel.Serialize(bw);
        bw.Write(TopMsgId);
    }

    public void Deserialize(BinaryReader br)
    {
        Channel = br.Deserialize<MyTelegram.Schema.IInputChannel>();
        TopMsgId = br.ReadInt32();
    }
}
