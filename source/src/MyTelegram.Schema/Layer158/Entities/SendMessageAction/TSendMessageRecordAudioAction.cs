﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/sendMessageRecordAudioAction" />
///</summary>
[TlObject(0xd52f73f7)]
public sealed class TSendMessageRecordAudioAction : ISendMessageAction
{
    public uint ConstructorId => 0xd52f73f7;


    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);

    }

    public void Deserialize(BinaryReader br)
    {

    }
}