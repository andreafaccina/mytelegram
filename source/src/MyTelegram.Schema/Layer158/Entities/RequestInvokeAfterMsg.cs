﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
///See <a href="https://core.telegram.org/method/invokeAfterMsg" />
///</summary>
[TlObject(0xcb9f372d)]
public sealed class RequestInvokeAfterMsg : IRequest<IObject>
{
    public uint ConstructorId => 0xcb9f372d;
    public long MsgId { get; set; }
    public IObject Query { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Write(MsgId);
        Query.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        MsgId = br.ReadInt64();
        Query = br.Deserialize<IObject>();
    }
}
