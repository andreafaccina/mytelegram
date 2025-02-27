﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
///See <a href="https://core.telegram.org/method/messages.setInlineGameScore" />
///</summary>
[TlObject(0x15ad9f64)]
public sealed class RequestSetInlineGameScore : IRequest<IBool>
{
    public uint ConstructorId => 0x15ad9f64;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool EditMessage { get; set; }
    public bool Force { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputBotInlineMessageID" />
    ///</summary>
    public MyTelegram.Schema.IInputBotInlineMessageID Id { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser UserId { get; set; }
    public int Score { get; set; }

    public void ComputeFlag()
    {
        if (EditMessage) { Flags[0] = true; }
        if (Force) { Flags[1] = true; }

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        Id.Serialize(bw);
        UserId.Serialize(bw);
        bw.Write(Score);
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[0]) { EditMessage = true; }
        if (Flags[1]) { Force = true; }
        Id = br.Deserialize<MyTelegram.Schema.IInputBotInlineMessageID>();
        UserId = br.Deserialize<MyTelegram.Schema.IInputUser>();
        Score = br.ReadInt32();
    }
}
