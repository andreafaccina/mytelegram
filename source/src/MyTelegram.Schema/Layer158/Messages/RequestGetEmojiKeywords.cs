﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
///See <a href="https://core.telegram.org/method/messages.getEmojiKeywords" />
///</summary>
[TlObject(0x35a0e062)]
public sealed class RequestGetEmojiKeywords : IRequest<MyTelegram.Schema.IEmojiKeywordsDifference>
{
    public uint ConstructorId => 0x35a0e062;
    public string LangCode { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(LangCode);
    }

    public void Deserialize(BinaryReader br)
    {
        LangCode = br.Deserialize<string>();
    }
}
