﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
///See <a href="https://core.telegram.org/method/channels.getForumTopicsByID" />
///</summary>
[TlObject(0xb0831eb9)]
public sealed class RequestGetForumTopicsByID : IRequest<MyTelegram.Schema.Messages.IForumTopics>
{
    public uint ConstructorId => 0xb0831eb9;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputChannel" />
    ///</summary>
    public MyTelegram.Schema.IInputChannel Channel { get; set; }
    public TVector<int> Topics { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Channel.Serialize(bw);
        Topics.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Channel = br.Deserialize<MyTelegram.Schema.IInputChannel>();
        Topics = br.Deserialize<TVector<int>>();
    }
}
