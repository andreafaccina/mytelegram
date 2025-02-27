﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Upload;


///<summary>
///See <a href="https://core.telegram.org/constructor/upload.cdnFile" />
///</summary>
[TlObject(0xa99fca4f)]
public sealed class TCdnFile : ICdnFile
{
    public uint ConstructorId => 0xa99fca4f;
    public byte[] Bytes { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Bytes);
    }

    public void Deserialize(BinaryReader br)
    {
        Bytes = br.Deserialize<byte[]>();
    }
}