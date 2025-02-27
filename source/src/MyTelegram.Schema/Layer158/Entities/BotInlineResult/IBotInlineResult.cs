﻿// ReSharper disable All

namespace MyTelegram.Schema;

public interface IBotInlineResult : IObject
{
    BitArray Flags { get; set; }
    string Id { get; set; }
    string Type { get; set; }
    Schema.IBotInlineMessage SendMessage { get; set; }
}
