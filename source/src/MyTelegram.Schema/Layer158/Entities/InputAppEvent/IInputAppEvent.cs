﻿// ReSharper disable All

namespace MyTelegram.Schema;

public interface IInputAppEvent : IObject
{
    double Time { get; set; }
    string Type { get; set; }
    long Peer { get; set; }
    Schema.IJSONValue Data { get; set; }
}
