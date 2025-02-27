﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/updatePinnedMessages" />
///</summary>
[TlObject(0xed85eab5)]
public sealed class TUpdatePinnedMessages : IUpdate
{
    public uint ConstructorId => 0xed85eab5;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool Pinned { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/Peer" />
    ///</summary>
    public MyTelegram.Schema.IPeer Peer { get; set; }
    public TVector<int> Messages { get; set; }
    public int Pts { get; set; }
    public int PtsCount { get; set; }

    public void ComputeFlag()
    {
        if (Pinned) { Flags[0] = true; }

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        Peer.Serialize(bw);
        Messages.Serialize(bw);
        bw.Write(Pts);
        bw.Write(PtsCount);
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[0]) { Pinned = true; }
        Peer = br.Deserialize<MyTelegram.Schema.IPeer>();
        Messages = br.Deserialize<TVector<int>>();
        Pts = br.ReadInt32();
        PtsCount = br.ReadInt32();
    }
}