﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Payments;

///<summary>
///See <a href="https://core.telegram.org/method/payments.getSavedInfo" />
///</summary>
[TlObject(0x227d824b)]
public sealed class RequestGetSavedInfo : IRequest<MyTelegram.Schema.Payments.ISavedInfo>
{
    public uint ConstructorId => 0x227d824b;

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
