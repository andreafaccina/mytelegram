﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/updatePhoneCall" />
///</summary>
[TlObject(0xab0f6b1e)]
public sealed class TUpdatePhoneCall : IUpdate
{
    public uint ConstructorId => 0xab0f6b1e;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/PhoneCall" />
    ///</summary>
    public MyTelegram.Schema.IPhoneCall PhoneCall { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        PhoneCall.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        PhoneCall = br.Deserialize<MyTelegram.Schema.IPhoneCall>();
    }
}