﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/updateStickerSetsOrder" />
///</summary>
[TlObject(0xbb2d201)]
public sealed class TUpdateStickerSetsOrder : IUpdate
{
    public uint ConstructorId => 0xbb2d201;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool Masks { get; set; }
    public bool Emojis { get; set; }
    public TVector<long> Order { get; set; }

    public void ComputeFlag()
    {
        if (Masks) { Flags[0] = true; }
        if (Emojis) { Flags[1] = true; }

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        Order.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[0]) { Masks = true; }
        if (Flags[1]) { Emojis = true; }
        Order = br.Deserialize<TVector<long>>();
    }
}