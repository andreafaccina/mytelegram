﻿// ReSharper disable All

namespace MyTelegram.Schema.Messages;

public interface IForumTopics : IObject
{
    BitArray Flags { get; set; }
    bool OrderByCreateDate { get; set; }
    int Count { get; set; }
    TVector<Schema.IForumTopic> Topics { get; set; }
    TVector<Schema.IMessage> Messages { get; set; }
    TVector<Schema.IChat> Chats { get; set; }
    TVector<Schema.IUser> Users { get; set; }
    int Pts { get; set; }
}
