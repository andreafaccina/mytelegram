﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Stickers;

///<summary>
///See <a href="https://core.telegram.org/method/stickers.addStickerToSet" />
///</summary>
[TlObject(0x8653febe)]
public sealed class RequestAddStickerToSet : IRequest<MyTelegram.Schema.Messages.IStickerSet>
{
    public uint ConstructorId => 0x8653febe;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputStickerSet" />
    ///</summary>
    public MyTelegram.Schema.IInputStickerSet Stickerset { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputStickerSetItem" />
    ///</summary>
    public MyTelegram.Schema.IInputStickerSetItem Sticker { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Stickerset.Serialize(bw);
        Sticker.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Stickerset = br.Deserialize<MyTelegram.Schema.IInputStickerSet>();
        Sticker = br.Deserialize<MyTelegram.Schema.IInputStickerSetItem>();
    }
}
