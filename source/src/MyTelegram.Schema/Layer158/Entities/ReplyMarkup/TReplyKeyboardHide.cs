﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/replyKeyboardHide" />
///</summary>
[TlObject(0xa03e5b85)]
public sealed class TReplyKeyboardHide : IReplyMarkup
{
    public uint ConstructorId => 0xa03e5b85;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool Selective { get; set; }

    public void ComputeFlag()
    {
        if (Selective) { Flags[2] = true; }
    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);

    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[2]) { Selective = true; }
    }
}