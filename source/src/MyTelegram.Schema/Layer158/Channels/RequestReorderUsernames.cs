﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
///See <a href="https://core.telegram.org/method/channels.reorderUsernames" />
///</summary>
[TlObject(0xb45ced1d)]
public sealed class RequestReorderUsernames : IRequest<IBool>
{
    public uint ConstructorId => 0xb45ced1d;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputChannel" />
    ///</summary>
    public MyTelegram.Schema.IInputChannel Channel { get; set; }
    public TVector<string> Order { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Channel.Serialize(bw);
        Order.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Channel = br.Deserialize<MyTelegram.Schema.IInputChannel>();
        Order = br.Deserialize<TVector<string>>();
    }
}
