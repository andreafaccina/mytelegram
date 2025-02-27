﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;


///<summary>
///See <a href="https://core.telegram.org/constructor/channels.channelParticipants" />
///</summary>
[TlObject(0x9ab0feaf)]
public sealed class TChannelParticipants : IChannelParticipants
{
    public uint ConstructorId => 0x9ab0feaf;
    public int Count { get; set; }
    public TVector<MyTelegram.Schema.IChannelParticipant> Participants { get; set; }
    public TVector<MyTelegram.Schema.IChat> Chats { get; set; }
    public TVector<MyTelegram.Schema.IUser> Users { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Write(Count);
        Participants.Serialize(bw);
        Chats.Serialize(bw);
        Users.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Count = br.ReadInt32();
        Participants = br.Deserialize<TVector<MyTelegram.Schema.IChannelParticipant>>();
        Chats = br.Deserialize<TVector<MyTelegram.Schema.IChat>>();
        Users = br.Deserialize<TVector<MyTelegram.Schema.IUser>>();
    }
}