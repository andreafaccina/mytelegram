﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Account;


///<summary>
///See <a href="https://core.telegram.org/constructor/account.savedRingtone" />
///</summary>
[TlObject(0xb7263f6d)]
public sealed class TSavedRingtone : ISavedRingtone
{
    public uint ConstructorId => 0xb7263f6d;


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