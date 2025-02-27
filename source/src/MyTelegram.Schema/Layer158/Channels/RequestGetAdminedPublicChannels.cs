﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
///See <a href="https://core.telegram.org/method/channels.getAdminedPublicChannels" />
///</summary>
[TlObject(0xf8b036af)]
public sealed class RequestGetAdminedPublicChannels : IRequest<MyTelegram.Schema.Messages.IChats>
{
    public uint ConstructorId => 0xf8b036af;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool ByLocation { get; set; }
    public bool CheckLimit { get; set; }

    public void ComputeFlag()
    {
        if (ByLocation) { Flags[0] = true; }
        if (CheckLimit) { Flags[1] = true; }
    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);

    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[0]) { ByLocation = true; }
        if (Flags[1]) { CheckLimit = true; }
    }
}
