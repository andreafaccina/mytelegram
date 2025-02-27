﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/updateShortMessage" />
///</summary>
[TlObject(0x313bc7f8)]
public sealed class TUpdateShortMessage : IUpdates
{
    public uint ConstructorId => 0x313bc7f8;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool Out { get; set; }
    public bool Mentioned { get; set; }
    public bool MediaUnread { get; set; }
    public bool Silent { get; set; }
    public int Id { get; set; }
    public long UserId { get; set; }
    public string Message { get; set; }
    public int Pts { get; set; }
    public int PtsCount { get; set; }
    public int Date { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/MessageFwdHeader" />
    ///</summary>
    public MyTelegram.Schema.IMessageFwdHeader? FwdFrom { get; set; }
    public long? ViaBotId { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/MessageReplyHeader" />
    ///</summary>
    public MyTelegram.Schema.IMessageReplyHeader? ReplyTo { get; set; }
    public TVector<MyTelegram.Schema.IMessageEntity>? Entities { get; set; }
    public int? TtlPeriod { get; set; }

    public void ComputeFlag()
    {
        if (Out) { Flags[1] = true; }
        if (Mentioned) { Flags[4] = true; }
        if (MediaUnread) { Flags[5] = true; }
        if (Silent) { Flags[13] = true; }
        if (FwdFrom != null) { Flags[2] = true; }
        if (ViaBotId != 0 && ViaBotId.HasValue) { Flags[11] = true; }
        if (ReplyTo != null) { Flags[3] = true; }
        if (Entities?.Count > 0) { Flags[7] = true; }
        if (TtlPeriod != 0 && TtlPeriod.HasValue) { Flags[25] = true; }
    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        bw.Write(Id);
        bw.Write(UserId);
        bw.Serialize(Message);
        bw.Write(Pts);
        bw.Write(PtsCount);
        bw.Write(Date);
        if (Flags[2]) { FwdFrom.Serialize(bw); }
        if (Flags[11]) { bw.Write(ViaBotId.Value); }
        if (Flags[3]) { ReplyTo.Serialize(bw); }
        if (Flags[7]) { Entities.Serialize(bw); }
        if (Flags[25]) { bw.Write(TtlPeriod.Value); }
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[1]) { Out = true; }
        if (Flags[4]) { Mentioned = true; }
        if (Flags[5]) { MediaUnread = true; }
        if (Flags[13]) { Silent = true; }
        Id = br.ReadInt32();
        UserId = br.ReadInt64();
        Message = br.Deserialize<string>();
        Pts = br.ReadInt32();
        PtsCount = br.ReadInt32();
        Date = br.ReadInt32();
        if (Flags[2]) { FwdFrom = br.Deserialize<MyTelegram.Schema.IMessageFwdHeader>(); }
        if (Flags[11]) { ViaBotId = br.ReadInt64(); }
        if (Flags[3]) { ReplyTo = br.Deserialize<MyTelegram.Schema.IMessageReplyHeader>(); }
        if (Flags[7]) { Entities = br.Deserialize<TVector<MyTelegram.Schema.IMessageEntity>>(); }
        if (Flags[25]) { TtlPeriod = br.ReadInt32(); }
    }
}