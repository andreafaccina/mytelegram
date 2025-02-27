﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Account;


///<summary>
///See <a href="https://core.telegram.org/constructor/account.emailVerified" />
///</summary>
[TlObject(0x2b96cd1b)]
public sealed class TEmailVerified : IEmailVerified
{
    public uint ConstructorId => 0x2b96cd1b;
    public string Email { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Email);
    }

    public void Deserialize(BinaryReader br)
    {
        Email = br.Deserialize<string>();
    }
}