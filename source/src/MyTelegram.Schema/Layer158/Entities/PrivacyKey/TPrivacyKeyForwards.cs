﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/privacyKeyForwards" />
///</summary>
[TlObject(0x69ec56a3)]
public sealed class TPrivacyKeyForwards : IPrivacyKey
{
    public uint ConstructorId => 0x69ec56a3;


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