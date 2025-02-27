﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Chatlists;


///<summary>
///See <a href="https://core.telegram.org/constructor/chatlists.chatlistInviteAlready" />
///</summary>
[TlObject(0xfa87f659)]
public sealed class TChatlistInviteAlready : IChatlistInvite
{
    public uint ConstructorId => 0xfa87f659;
    public int FilterId { get; set; }
    public TVector<MyTelegram.Schema.IPeer> MissingPeers { get; set; }
    public TVector<MyTelegram.Schema.IPeer> AlreadyPeers { get; set; }
    public TVector<MyTelegram.Schema.IChat> Chats { get; set; }
    public TVector<MyTelegram.Schema.IUser> Users { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Write(FilterId);
        MissingPeers.Serialize(bw);
        AlreadyPeers.Serialize(bw);
        Chats.Serialize(bw);
        Users.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        FilterId = br.ReadInt32();
        MissingPeers = br.Deserialize<TVector<MyTelegram.Schema.IPeer>>();
        AlreadyPeers = br.Deserialize<TVector<MyTelegram.Schema.IPeer>>();
        Chats = br.Deserialize<TVector<MyTelegram.Schema.IChat>>();
        Users = br.Deserialize<TVector<MyTelegram.Schema.IUser>>();
    }
}