﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Account;

///<summary>
///See <a href="https://core.telegram.org/method/account.getChatThemes" />
///</summary>
[TlObject(0xd638de89)]
public sealed class RequestGetChatThemes : IRequest<MyTelegram.Schema.Account.IThemes>
{
    public uint ConstructorId => 0xd638de89;
    public long Hash { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Write(Hash);
    }

    public void Deserialize(BinaryReader br)
    {
        Hash = br.ReadInt64();
    }
}
