﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/jsonString" />
///</summary>
[TlObject(0xb71e767a)]
public sealed class TJsonString : IJSONValue
{
    public uint ConstructorId => 0xb71e767a;
    public string Value { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Value);
    }

    public void Deserialize(BinaryReader br)
    {
        Value = br.Deserialize<string>();
    }
}