﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/updateReadHistoryInbox" />
///</summary>
[TlObject(0x9c974fdf)]
public sealed class TUpdateReadHistoryInbox : IUpdate
{
    public uint ConstructorId => 0x9c974fdf;
    public BitArray Flags { get; set; } = new BitArray(32);
    public int? FolderId { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/Peer" />
    ///</summary>
    public MyTelegram.Schema.IPeer Peer { get; set; }
    public int MaxId { get; set; }
    public int StillUnreadCount { get; set; }
    public int Pts { get; set; }
    public int PtsCount { get; set; }

    public void ComputeFlag()
    {
        if (FolderId != 0 && FolderId.HasValue) { Flags[0] = true; }

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        if (Flags[0]) { bw.Write(FolderId.Value); }
        Peer.Serialize(bw);
        bw.Write(MaxId);
        bw.Write(StillUnreadCount);
        bw.Write(Pts);
        bw.Write(PtsCount);
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[0]) { FolderId = br.ReadInt32(); }
        Peer = br.Deserialize<MyTelegram.Schema.IPeer>();
        MaxId = br.ReadInt32();
        StillUnreadCount = br.ReadInt32();
        Pts = br.ReadInt32();
        PtsCount = br.ReadInt32();
    }
}