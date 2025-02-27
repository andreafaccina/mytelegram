﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Contacts;

///<summary>
///See <a href="https://core.telegram.org/method/contacts.deleteByPhones" />
///</summary>
[TlObject(0x1013fd9e)]
public sealed class RequestDeleteByPhones : IRequest<IBool>
{
    public uint ConstructorId => 0x1013fd9e;
    public TVector<string> Phones { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Phones.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Phones = br.Deserialize<TVector<string>>();
    }
}
