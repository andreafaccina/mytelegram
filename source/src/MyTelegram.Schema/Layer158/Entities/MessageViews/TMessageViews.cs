﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/messageViews" />
///</summary>
[TlObject(0x455b853d)]
public sealed class TMessageViews : IMessageViews
{
    public uint ConstructorId => 0x455b853d;
    public BitArray Flags { get; set; } = new BitArray(32);
    public int? Views { get; set; }
    public int? Forwards { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/MessageReplies" />
    ///</summary>
    public MyTelegram.Schema.IMessageReplies? Replies { get; set; }

    public void ComputeFlag()
    {
        if (Views != 0 && Views.HasValue) { Flags[0] = true; }
        if (Forwards != 0 && Forwards.HasValue) { Flags[1] = true; }
        if (Replies != null) { Flags[2] = true; }
    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        if (Flags[0]) { bw.Write(Views.Value); }
        if (Flags[1]) { bw.Write(Forwards.Value); }
        if (Flags[2]) { Replies.Serialize(bw); }
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[0]) { Views = br.ReadInt32(); }
        if (Flags[1]) { Forwards = br.ReadInt32(); }
        if (Flags[2]) { Replies = br.Deserialize<MyTelegram.Schema.IMessageReplies>(); }
    }
}