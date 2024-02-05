using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to remove a message from the list of pinned messages in a chat. If the chat is not
/// a private chat, the bot must be an administrator in the chat for this to work and must have the
/// '<see cref="ChatMemberAdministrator.CanPinMessages"/>' admin right in a supergroup or
/// '<see cref="ChatMemberAdministrator.CanEditMessages"/>' admin right in a channel.
/// Returns <see langword="true"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class UnpinChatMessageRequest : RequestBase<bool>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// Identifier of a message to unpin. If not specified, the most recent pinned message
    /// (by sending date) will be unpinned.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? MessageId { get; set; }

    /// <summary>
    /// Initializes a new request with chatId
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    public UnpinChatMessageRequest(ChatId chatId)
        : base("unpinChatMessage")
    {
        ChatId = chatId;
    }
}
