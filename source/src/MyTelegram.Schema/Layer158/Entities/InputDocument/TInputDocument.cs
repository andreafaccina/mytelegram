﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/inputDocument" />
///</summary>
[TlObject(0x1abfb575)]
public sealed class TInputDocument : IInputDocument
{
    public uint ConstructorId => 0x1abfb575;
    public long Id { get; set; }
    public long AccessHash { get; set; }
    public byte[] FileReference { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Write(Id);
        bw.Write(AccessHash);
        bw.Serialize(FileReference);
    }

    public void Deserialize(BinaryReader br)
    {
        Id = br.ReadInt64();
        AccessHash = br.ReadInt64();
        FileReference = br.Deserialize<byte[]>();
    }
}