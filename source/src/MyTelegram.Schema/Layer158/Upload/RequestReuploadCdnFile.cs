﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Upload;

///<summary>
///See <a href="https://core.telegram.org/method/upload.reuploadCdnFile" />
///</summary>
[TlObject(0x9b2754a8)]
public sealed class RequestReuploadCdnFile : IRequest<TVector<MyTelegram.Schema.IFileHash>>
{
    public uint ConstructorId => 0x9b2754a8;
    public byte[] FileToken { get; set; }
    public byte[] RequestToken { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(FileToken);
        bw.Serialize(RequestToken);
    }

    public void Deserialize(BinaryReader br)
    {
        FileToken = br.Deserialize<byte[]>();
        RequestToken = br.Deserialize<byte[]>();
    }
}
