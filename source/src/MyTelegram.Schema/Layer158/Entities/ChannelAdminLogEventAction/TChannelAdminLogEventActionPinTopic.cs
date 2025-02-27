﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionPinTopic" />
///</summary>
[TlObject(0x5d8d353b)]
public sealed class TChannelAdminLogEventActionPinTopic : IChannelAdminLogEventAction
{
    public uint ConstructorId => 0x5d8d353b;
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    ///See <a href="https://core.telegram.org/type/ForumTopic" />
    ///</summary>
    public MyTelegram.Schema.IForumTopic? PrevTopic { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/ForumTopic" />
    ///</summary>
    public MyTelegram.Schema.IForumTopic? NewTopic { get; set; }

    public void ComputeFlag()
    {
        if (PrevTopic != null) { Flags[0] = true; }
        if (NewTopic != null) { Flags[1] = true; }
    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        if (Flags[0]) { PrevTopic.Serialize(bw); }
        if (Flags[1]) { NewTopic.Serialize(bw); }
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[0]) { PrevTopic = br.Deserialize<MyTelegram.Schema.IForumTopic>(); }
        if (Flags[1]) { NewTopic = br.Deserialize<MyTelegram.Schema.IForumTopic>(); }
    }
}