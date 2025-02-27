﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/secureFile" />
///</summary>
[TlObject(0x7d09c27e)]
public sealed class TSecureFile : ISecureFile
{
    public uint ConstructorId => 0x7d09c27e;
    public long Id { get; set; }
    public long AccessHash { get; set; }
    public long Size { get; set; }
    public int DcId { get; set; }
    public int Date { get; set; }
    public byte[] FileHash { get; set; }
    public byte[] Secret { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Write(Id);
        bw.Write(AccessHash);
        bw.Write(Size);
        bw.Write(DcId);
        bw.Write(Date);
        bw.Serialize(FileHash);
        bw.Serialize(Secret);
    }

    public void Deserialize(BinaryReader br)
    {
        Id = br.ReadInt64();
        AccessHash = br.ReadInt64();
        Size = br.ReadInt64();
        DcId = br.ReadInt32();
        Date = br.ReadInt32();
        FileHash = br.Deserialize<byte[]>();
        Secret = br.Deserialize<byte[]>();
    }
}