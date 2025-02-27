﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Users;

///<summary>
///See <a href="https://core.telegram.org/method/users.getFullUser" />
///</summary>
[TlObject(0xb60f5918)]
public sealed class RequestGetFullUser : IRequest<MyTelegram.Schema.Users.IUserFull>
{
    public uint ConstructorId => 0xb60f5918;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser Id { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Id.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Id = br.Deserialize<MyTelegram.Schema.IInputUser>();
    }
}
