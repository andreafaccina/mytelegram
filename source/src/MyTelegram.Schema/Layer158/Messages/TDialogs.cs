﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;


///<summary>
///See <a href="https://core.telegram.org/constructor/messages.dialogs" />
///</summary>
[TlObject(0x15ba6c40)]
public sealed class TDialogs : IDialogs
{
    public uint ConstructorId => 0x15ba6c40;
    public TVector<MyTelegram.Schema.IDialog> Dialogs { get; set; }
    public TVector<MyTelegram.Schema.IMessage> Messages { get; set; }
    public TVector<MyTelegram.Schema.IChat> Chats { get; set; }
    public TVector<MyTelegram.Schema.IUser> Users { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Dialogs.Serialize(bw);
        Messages.Serialize(bw);
        Chats.Serialize(bw);
        Users.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Dialogs = br.Deserialize<TVector<MyTelegram.Schema.IDialog>>();
        Messages = br.Deserialize<TVector<MyTelegram.Schema.IMessage>>();
        Chats = br.Deserialize<TVector<MyTelegram.Schema.IChat>>();
        Users = br.Deserialize<TVector<MyTelegram.Schema.IUser>>();
    }
}