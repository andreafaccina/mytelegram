﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/username" />
///</summary>
[TlObject(0xb4073647)]
public sealed class TUsername : IUsername
{
    public uint ConstructorId => 0xb4073647;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool Editable { get; set; }
    public bool Active { get; set; }
    public string Username { get; set; }

    public void ComputeFlag()
    {
        if (Editable) { Flags[0] = true; }
        if (Active) { Flags[1] = true; }

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        bw.Serialize(Username);
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[0]) { Editable = true; }
        if (Flags[1]) { Active = true; }
        Username = br.Deserialize<string>();
    }
}