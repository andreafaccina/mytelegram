﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/inputStickerSetAnimatedEmojiAnimations" />
///</summary>
[TlObject(0xcde3739)]
public sealed class TInputStickerSetAnimatedEmojiAnimations : IInputStickerSet
{
    public uint ConstructorId => 0xcde3739;


    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);

    }

    public void Deserialize(BinaryReader br)
    {

    }
}