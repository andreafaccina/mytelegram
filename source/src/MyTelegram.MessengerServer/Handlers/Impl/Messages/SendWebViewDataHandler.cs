﻿// ReSharper disable All

using MyTelegram.Schema.Messages;

namespace MyTelegram.Handlers.Messages;

public class SendWebViewDataHandler : RpcResultObjectHandler<RequestSendWebViewData, Schema.IUpdates>,
    Messages.ISendWebViewDataHandler
{
    protected override Task<Schema.IUpdates> HandleCoreAsync(IRequestInput input,
        RequestSendWebViewData obj)
    {
        throw new NotImplementedException();
    }
}