﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Help;


///<summary>
///See <a href="https://core.telegram.org/constructor/help.countryCode" />
///</summary>
[TlObject(0x4203c5ef)]
public sealed class TCountryCode : ICountryCode
{
    public uint ConstructorId => 0x4203c5ef;
    public BitArray Flags { get; set; } = new BitArray(32);
    public string CountryCode { get; set; }
    public TVector<string>? Prefixes { get; set; }
    public TVector<string>? Patterns { get; set; }

    public void ComputeFlag()
    {
        if (Prefixes?.Count > 0) { Flags[0] = true; }
        if (Patterns?.Count > 0) { Flags[1] = true; }
    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        bw.Serialize(CountryCode);
        if (Flags[0]) { Prefixes.Serialize(bw); }
        if (Flags[1]) { Patterns.Serialize(bw); }
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        CountryCode = br.Deserialize<string>();
        if (Flags[0]) { Prefixes = br.Deserialize<TVector<string>>(); }
        if (Flags[1]) { Patterns = br.Deserialize<TVector<string>>(); }
    }
}