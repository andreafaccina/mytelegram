﻿// ReSharper disable All

namespace MyTelegram.Schema.Messages;

public interface ISearchResultsCalendar : IObject
{
    BitArray Flags { get; set; }
    bool Inexact { get; set; }
    int Count { get; set; }
    int MinDate { get; set; }
    int MinMsgId { get; set; }
    int? OffsetIdOffset { get; set; }
    TVector<Schema.ISearchResultsCalendarPeriod> Periods { get; set; }
    TVector<Schema.IMessage> Messages { get; set; }
    TVector<Schema.IChat> Chats { get; set; }
    TVector<Schema.IUser> Users { get; set; }
}
