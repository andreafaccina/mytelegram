﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Contacts;

///<summary>
///See <a href="https://core.telegram.org/method/contacts.resetTopPeerRating" />
///</summary>
[TlObject(0x1ae373ac)]
public sealed class RequestResetTopPeerRating : IRequest<IBool>
{
    public uint ConstructorId => 0x1ae373ac;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/TopPeerCategory" />
    ///</summary>
    public MyTelegram.Schema.ITopPeerCategory Category { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer Peer { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Category.Serialize(bw);
        Peer.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Category = br.Deserialize<MyTelegram.Schema.ITopPeerCategory>();
        Peer = br.Deserialize<MyTelegram.Schema.IInputPeer>();
    }
}
