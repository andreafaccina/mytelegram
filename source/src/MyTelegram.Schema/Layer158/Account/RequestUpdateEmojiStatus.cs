﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Account;

///<summary>
///See <a href="https://core.telegram.org/method/account.updateEmojiStatus" />
///</summary>
[TlObject(0xfbd3de6b)]
public sealed class RequestUpdateEmojiStatus : IRequest<IBool>
{
    public uint ConstructorId => 0xfbd3de6b;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/EmojiStatus" />
    ///</summary>
    public MyTelegram.Schema.IEmojiStatus EmojiStatus { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        EmojiStatus.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        EmojiStatus = br.Deserialize<MyTelegram.Schema.IEmojiStatus>();
    }
}
