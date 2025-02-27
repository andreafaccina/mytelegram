﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
///See <a href="https://core.telegram.org/method/channels.inviteToChannel" />
///</summary>
[TlObject(0x199f3a6c)]
public sealed class RequestInviteToChannel : IRequest<MyTelegram.Schema.IUpdates>
{
    public uint ConstructorId => 0x199f3a6c;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputChannel" />
    ///</summary>
    public MyTelegram.Schema.IInputChannel Channel { get; set; }
    public TVector<MyTelegram.Schema.IInputUser> Users { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Channel.Serialize(bw);
        Users.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Channel = br.Deserialize<MyTelegram.Schema.IInputChannel>();
        Users = br.Deserialize<TVector<MyTelegram.Schema.IInputUser>>();
    }
}
