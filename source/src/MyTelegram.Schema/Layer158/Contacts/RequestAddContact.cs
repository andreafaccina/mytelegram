﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Contacts;

///<summary>
///See <a href="https://core.telegram.org/method/contacts.addContact" />
///</summary>
[TlObject(0xe8f463d0)]
public sealed class RequestAddContact : IRequest<MyTelegram.Schema.IUpdates>
{
    public uint ConstructorId => 0xe8f463d0;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool AddPhonePrivacyException { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }

    public void ComputeFlag()
    {
        if (AddPhonePrivacyException) { Flags[0] = true; }

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        Id.Serialize(bw);
        bw.Serialize(FirstName);
        bw.Serialize(LastName);
        bw.Serialize(Phone);
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[0]) { AddPhonePrivacyException = true; }
        Id = br.Deserialize<MyTelegram.Schema.IInputUser>();
        FirstName = br.Deserialize<string>();
        LastName = br.Deserialize<string>();
        Phone = br.Deserialize<string>();
    }
}
