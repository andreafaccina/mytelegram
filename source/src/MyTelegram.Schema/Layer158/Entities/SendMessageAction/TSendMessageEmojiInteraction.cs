﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/sendMessageEmojiInteraction" />
///</summary>
[TlObject(0x25972bcb)]
public sealed class TSendMessageEmojiInteraction : ISendMessageAction
{
    public uint ConstructorId => 0x25972bcb;
    public string Emoticon { get; set; }
    public int MsgId { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/DataJSON" />
    ///</summary>
    public MyTelegram.Schema.IDataJSON Interaction { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Emoticon);
        bw.Write(MsgId);
        Interaction.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Emoticon = br.Deserialize<string>();
        MsgId = br.ReadInt32();
        Interaction = br.Deserialize<MyTelegram.Schema.IDataJSON>();
    }
}