﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/messageInteractionCounters" />
///</summary>
[TlObject(0xad4fc9bd)]
public sealed class TMessageInteractionCounters : IMessageInteractionCounters
{
    public uint ConstructorId => 0xad4fc9bd;
    public int MsgId { get; set; }
    public int Views { get; set; }
    public int Forwards { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Write(MsgId);
        bw.Write(Views);
        bw.Write(Forwards);
    }

    public void Deserialize(BinaryReader br)
    {
        MsgId = br.ReadInt32();
        Views = br.ReadInt32();
        Forwards = br.ReadInt32();
    }
}