﻿global using EventFlow.Aggregates;
global using EventFlow.Aggregates.ExecutionResults;
global using EventFlow.Commands;
global using EventFlow.Core;
global using EventFlow.Entities;
global using EventFlow.EventStores;
global using EventFlow.Extensions;
global using EventFlow.Provided.Specifications;
global using EventFlow.Sagas;
global using EventFlow.Sagas.AggregateSagas;
global using EventFlow.Snapshots;
global using EventFlow.Snapshots.Stores;
global using EventFlow.Snapshots.Strategies;
global using EventFlow.Specifications;
global using EventFlow.ValueObjects;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using MyTelegram.Domain.Aggregates.AppCode;
global using MyTelegram.Domain.Aggregates.Channel;
global using MyTelegram.Domain.Aggregates.Chat;
global using MyTelegram.Domain.Aggregates.Device;
global using MyTelegram.Domain.Aggregates.Dialog;
global using MyTelegram.Domain.Aggregates.Messaging;
global using MyTelegram.Domain.Aggregates.PeerNotifySettings;
global using MyTelegram.Domain.Aggregates.Poll;
global using MyTelegram.Domain.Aggregates.Pts;
global using MyTelegram.Domain.Aggregates.PushDevice;
global using MyTelegram.Domain.Aggregates.PushUpdates;
global using MyTelegram.Domain.Aggregates.QrCode;
global using MyTelegram.Domain.Aggregates.RpcResult;
global using MyTelegram.Domain.Aggregates.User;
global using MyTelegram.Domain.Aggregates.UserName;
global using MyTelegram.Domain.Commands.AppCode;
global using MyTelegram.Domain.Commands.Channel;
global using MyTelegram.Domain.Commands.Chat;
global using MyTelegram.Domain.Commands.Device;
global using MyTelegram.Domain.Commands.Dialog;
global using MyTelegram.Domain.Commands.Messaging;
global using MyTelegram.Domain.Commands.Poll;
global using MyTelegram.Domain.Commands.Pts;
global using MyTelegram.Domain.Commands.PushDevice;
global using MyTelegram.Domain.Commands.PushUpdates;
global using MyTelegram.Domain.Commands.QrCode;
global using MyTelegram.Domain.Commands.RpcResult;
global using MyTelegram.Domain.Commands.User;
global using MyTelegram.Domain.Commands.UserName;
global using MyTelegram.Domain.Entities;
global using MyTelegram.Domain.EventFlow;
global using MyTelegram.Domain.Events;
global using MyTelegram.Domain.Events.AppCode;
global using MyTelegram.Domain.Events.Channel;
global using MyTelegram.Domain.Events.Chat;
global using MyTelegram.Domain.Events.Device;
global using MyTelegram.Domain.Events.Dialog;
global using MyTelegram.Domain.Events.Messaging;
global using MyTelegram.Domain.Events.PeerNotifySettings;
global using MyTelegram.Domain.Events.Pts;
global using MyTelegram.Domain.Events.PushDevice;
global using MyTelegram.Domain.Events.PushUpdates;
global using MyTelegram.Domain.Events.QrCode;
global using MyTelegram.Domain.Events.RpcResult;
global using MyTelegram.Domain.Events.User;
global using MyTelegram.Domain.Events.UserName;
global using MyTelegram.Domain.Extensions;
global using MyTelegram.Domain.Sagas.Events;
global using MyTelegram.Domain.Sagas.Identities;
global using MyTelegram.Domain.Sagas.States;
global using MyTelegram.Domain.Specifications;
//global using MyTelegram.Domain.Snapshots;
global using MyTelegram.Domain.ValueObjects;
global using System.Collections;
global using System.Text.Json.Serialization;
