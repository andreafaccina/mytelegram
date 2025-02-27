﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/inputPhotoLegacyFileLocation" />
///</summary>
[TlObject(0xd83466f3)]
public sealed class TInputPhotoLegacyFileLocation : IInputFileLocation
{
    public uint ConstructorId => 0xd83466f3;
    public long Id { get; set; }
    public long AccessHash { get; set; }
    public byte[] FileReference { get; set; }
    public long VolumeId { get; set; }
    public int LocalId { get; set; }
    public long Secret { get; set; }

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
        bw.Write(VolumeId);
        bw.Write(LocalId);
        bw.Write(Secret);
    }

    public void Deserialize(BinaryReader br)
    {
        Id = br.ReadInt64();
        AccessHash = br.ReadInt64();
        FileReference = br.Deserialize<byte[]>();
        VolumeId = br.ReadInt64();
        LocalId = br.ReadInt32();
        Secret = br.ReadInt64();
    }
}