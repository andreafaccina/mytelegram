﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/privacyValueDisallowChatParticipants" />
///</summary>
[TlObject(0x41c87565)]
public sealed class TPrivacyValueDisallowChatParticipants : IPrivacyRule
{
    public uint ConstructorId => 0x41c87565;
    public TVector<long> Chats { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Chats.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Chats = br.Deserialize<TVector<long>>();
    }
}