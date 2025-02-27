﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/updateBotShippingQuery" />
///</summary>
[TlObject(0xb5aefd7d)]
public sealed class TUpdateBotShippingQuery : IUpdate
{
    public uint ConstructorId => 0xb5aefd7d;
    public long QueryId { get; set; }
    public long UserId { get; set; }
    public byte[] Payload { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/PostAddress" />
    ///</summary>
    public MyTelegram.Schema.IPostAddress ShippingAddress { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Write(QueryId);
        bw.Write(UserId);
        bw.Serialize(Payload);
        ShippingAddress.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        QueryId = br.ReadInt64();
        UserId = br.ReadInt64();
        Payload = br.Deserialize<byte[]>();
        ShippingAddress = br.Deserialize<MyTelegram.Schema.IPostAddress>();
    }
}