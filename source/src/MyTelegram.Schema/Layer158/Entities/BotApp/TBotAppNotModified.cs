﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/botAppNotModified" />
///</summary>
[TlObject(0x5da674b7)]
public sealed class TBotAppNotModified : IBotApp
{
    public uint ConstructorId => 0x5da674b7;


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