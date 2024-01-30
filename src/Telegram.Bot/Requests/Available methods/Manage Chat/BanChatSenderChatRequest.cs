using Telegram.Bot.Converters;
using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this request to ban a channel chat in a supergroup or a channel. The owner of the chat will not be able
/// to send messages and join live streams on behalf of the chat, unless it is unbanned first. The bot must be
/// an administrator in the supergroup or channel for this to work and must have the appropriate administrator
/// rights. Returns <see langword="true"/> on success
/// </summary>
/// <param name="chatId">
/// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
/// </param>
/// <param name="senderChatId">
/// Unique identifier of the target sender chat
/// </param>
public class BanChatSenderChatRequest(ChatId chatId, long senderChatId)
    : RequestBase<bool>("banChatSenderChat"),
      IChatTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <summary>
    /// Unique identifier of the target sender chat
    /// </summary>
    public long SenderChatId { get; } = senderChatId;

    /// <summary>
    /// Date when the sender chat will be unbanned, unix time. If the chat is banned for more than 366 days or
    /// less than 30 seconds from the current time they are considered to be banned forever.
    /// </summary>
    [JsonConverter(typeof(NullableUnixDateTimeConverter))]
    public DateTime? UntilDate { get; set; }
}
