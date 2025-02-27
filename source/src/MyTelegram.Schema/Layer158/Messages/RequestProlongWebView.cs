﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
///See <a href="https://core.telegram.org/method/messages.prolongWebView" />
///</summary>
[TlObject(0x7ff34309)]
public sealed class RequestProlongWebView : IRequest<IBool>
{
    public uint ConstructorId => 0x7ff34309;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool Silent { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer Peer { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser Bot { get; set; }
    public long QueryId { get; set; }
    public int? ReplyToMsgId { get; set; }
    public int? TopMsgId { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer? SendAs { get; set; }

    public void ComputeFlag()
    {
        if (Silent) { Flags[5] = true; }
        if (ReplyToMsgId != 0 && ReplyToMsgId.HasValue) { Flags[0] = true; }
        if (TopMsgId != 0 && TopMsgId.HasValue) { Flags[9] = true; }
        if (SendAs != null) { Flags[13] = true; }
    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        Peer.Serialize(bw);
        Bot.Serialize(bw);
        bw.Write(QueryId);
        if (Flags[0]) { bw.Write(ReplyToMsgId.Value); }
        if (Flags[9]) { bw.Write(TopMsgId.Value); }
        if (Flags[13]) { SendAs.Serialize(bw); }
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[5]) { Silent = true; }
        Peer = br.Deserialize<MyTelegram.Schema.IInputPeer>();
        Bot = br.Deserialize<MyTelegram.Schema.IInputUser>();
        QueryId = br.ReadInt64();
        if (Flags[0]) { ReplyToMsgId = br.ReadInt32(); }
        if (Flags[9]) { TopMsgId = br.ReadInt32(); }
        if (Flags[13]) { SendAs = br.Deserialize<MyTelegram.Schema.IInputPeer>(); }
    }
}
