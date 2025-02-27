﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/chatInvitePeek" />
///</summary>
[TlObject(0x61695cb0)]
public sealed class TChatInvitePeek : IChatInvite
{
    public uint ConstructorId => 0x61695cb0;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/Chat" />
    ///</summary>
    public MyTelegram.Schema.IChat Chat { get; set; }
    public int Expires { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Chat.Serialize(bw);
        bw.Write(Expires);
    }

    public void Deserialize(BinaryReader br)
    {
        Chat = br.Deserialize<MyTelegram.Schema.IChat>();
        Expires = br.ReadInt32();
    }
}