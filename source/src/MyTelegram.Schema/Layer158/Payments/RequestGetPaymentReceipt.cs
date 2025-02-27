﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Payments;

///<summary>
///See <a href="https://core.telegram.org/method/payments.getPaymentReceipt" />
///</summary>
[TlObject(0x2478d1cc)]
public sealed class RequestGetPaymentReceipt : IRequest<MyTelegram.Schema.Payments.IPaymentReceipt>
{
    public uint ConstructorId => 0x2478d1cc;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer Peer { get; set; }
    public int MsgId { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Peer.Serialize(bw);
        bw.Write(MsgId);
    }

    public void Deserialize(BinaryReader br)
    {
        Peer = br.Deserialize<MyTelegram.Schema.IInputPeer>();
        MsgId = br.ReadInt32();
    }
}
