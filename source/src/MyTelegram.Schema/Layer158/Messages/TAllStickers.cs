﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;


///<summary>
///See <a href="https://core.telegram.org/constructor/messages.allStickers" />
///</summary>
[TlObject(0xcdbbcebb)]
public sealed class TAllStickers : IAllStickers
{
    public uint ConstructorId => 0xcdbbcebb;
    public long Hash { get; set; }
    public TVector<MyTelegram.Schema.IStickerSet> Sets { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Write(Hash);
        Sets.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Hash = br.ReadInt64();
        Sets = br.Deserialize<TVector<MyTelegram.Schema.IStickerSet>>();
    }
}