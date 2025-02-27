﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
///See <a href="https://core.telegram.org/method/messages.getDialogs" />
///</summary>
[TlObject(0xa0f4cb4f)]
public sealed class RequestGetDialogs : IRequest<MyTelegram.Schema.Messages.IDialogs>
{
    public uint ConstructorId => 0xa0f4cb4f;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool ExcludePinned { get; set; }
    public int? FolderId { get; set; }
    public int OffsetDate { get; set; }
    public int OffsetId { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer OffsetPeer { get; set; }
    public int Limit { get; set; }
    public long Hash { get; set; }

    public void ComputeFlag()
    {
        if (ExcludePinned) { Flags[0] = true; }
        if (FolderId != 0 && FolderId.HasValue) { Flags[1] = true; }

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        if (Flags[1]) { bw.Write(FolderId.Value); }
        bw.Write(OffsetDate);
        bw.Write(OffsetId);
        OffsetPeer.Serialize(bw);
        bw.Write(Limit);
        bw.Write(Hash);
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[0]) { ExcludePinned = true; }
        if (Flags[1]) { FolderId = br.ReadInt32(); }
        OffsetDate = br.ReadInt32();
        OffsetId = br.ReadInt32();
        OffsetPeer = br.Deserialize<MyTelegram.Schema.IInputPeer>();
        Limit = br.ReadInt32();
        Hash = br.ReadInt64();
    }
}
