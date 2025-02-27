﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Stats;

///<summary>
///See <a href="https://core.telegram.org/method/stats.loadAsyncGraph" />
///</summary>
[TlObject(0x621d5fa0)]
public sealed class RequestLoadAsyncGraph : IRequest<MyTelegram.Schema.IStatsGraph>
{
    public uint ConstructorId => 0x621d5fa0;
    public BitArray Flags { get; set; } = new BitArray(32);
    public string Token { get; set; }
    public long? X { get; set; }

    public void ComputeFlag()
    {
        if (X != 0 && X.HasValue) { Flags[0] = true; }
    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        bw.Serialize(Token);
        if (Flags[0]) { bw.Write(X.Value); }
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        Token = br.Deserialize<string>();
        if (Flags[0]) { X = br.ReadInt64(); }
    }
}
