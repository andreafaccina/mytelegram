﻿// <auto-generated/>
// ReSharper disable All

using MyTelegram.Schema.Messages;

namespace MyTelegram.Schema.LayerN;

[TlObject(0x93d7b347)]
public sealed class RequestGetChannelMessages : IRequest<IMessages>
{
    public Schema.IInputChannel Channel { get; set; }
    public TVector<int> Id { get; set; }
    public uint ConstructorId => 0x93d7b347;

    public void Serialize(BinaryWriter bw)
    {
        bw.Write(ConstructorId);
        ComputeFlag();
        SerializerFactory.CreateObjectSerializer<Schema.IInputChannel>().Serialize(Channel, bw);
        SerializerFactory.CreateObjectSerializer<TVector<int>>().Serialize(Id, bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Channel = SerializerFactory.CreateObjectSerializer<Schema.IInputChannel>().Deserialize(br);
        Id = SerializerFactory.CreateObjectSerializer<TVector<int>>().Deserialize(br);
    }

    public void ComputeFlag()
    {
    }
}

//layer 73
//auth.sendCode#86aef0ec allow_flashcall:true phone_number:string current_number:Bool api_id:int api_hash:string = auth.SentCode;
