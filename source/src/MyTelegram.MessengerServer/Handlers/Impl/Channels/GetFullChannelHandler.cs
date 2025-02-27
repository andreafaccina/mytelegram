using MyTelegram.Domain.Aggregates.PeerNotifySettings;
using MyTelegram.Handlers.Channels;
using MyTelegram.Schema.Channels;
using IChatFull = MyTelegram.Schema.Messages.IChatFull;

namespace MyTelegram.MessengerServer.Handlers.Impl.Channels;

public class GetFullChannelHandler : RpcResultObjectHandler<RequestGetFullChannel, IChatFull>,
    IGetFullChannelHandler, IProcessedHandler
{
    private readonly ITlChatConverter _chatConverter;
    private readonly IQueryProcessor _queryProcessor;

    public GetFullChannelHandler(IQueryProcessor queryProcessor,
        ITlChatConverter chatConverter)
    {
        _queryProcessor = queryProcessor;
        _chatConverter = chatConverter;
    }

    protected override async Task<IChatFull> HandleCoreAsync(IRequestInput input,
        RequestGetFullChannel obj)
    {
        if (obj.Channel is TInputChannel inputChannel)
        {
            var channel = await _queryProcessor.ProcessAsync(new GetChannelByIdQuery(inputChannel.ChannelId),
                CancellationToken.None);
            if (channel == null) ThrowHelper.ThrowUserFriendlyException("CHANNEL_INVALID");

            var channelFull = await _queryProcessor.ProcessAsync(new GetChannelFullByIdQuery(inputChannel.ChannelId),
                CancellationToken.None);
            var channelMember = await _queryProcessor
                    .ProcessAsync(new GetChannelMemberByUidQuery(inputChannel.ChannelId, input.UserId), default)
                ;
            var peerNotifySettings = await _queryProcessor
                .ProcessAsync(
                    new GetPeerNotifySettingsByIdQuery(PeerNotifySettingsId.Create(input.UserId,
                        PeerType.Channel,
                        inputChannel.ChannelId)),
                    CancellationToken.None);

            return _chatConverter.ToChatFull(channel!,
                channelFull!,
                channelMember,
                peerNotifySettings,
                input.UserId);
        }

        throw new NotImplementedException();
    }
}