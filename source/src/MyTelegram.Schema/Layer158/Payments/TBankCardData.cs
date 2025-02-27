﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Payments;


///<summary>
///See <a href="https://core.telegram.org/constructor/payments.bankCardData" />
///</summary>
[TlObject(0x3e24e573)]
public sealed class TBankCardData : IBankCardData
{
    public uint ConstructorId => 0x3e24e573;
    public string Title { get; set; }
    public TVector<MyTelegram.Schema.IBankCardOpenUrl> OpenUrls { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Title);
        OpenUrls.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Title = br.Deserialize<string>();
        OpenUrls = br.Deserialize<TVector<MyTelegram.Schema.IBankCardOpenUrl>>();
    }
}