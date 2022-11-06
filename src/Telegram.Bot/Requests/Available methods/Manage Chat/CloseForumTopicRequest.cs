using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this request to close an open topic in a forum supergroup chat. The bot must be an administrator in the chat
/// for this to work and must have the <see cref="ChatAdministratorRights.CanManageTopics"/> administrator rights,
/// unless it is the creator of the topic. Returns <c>true</c> on success.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class CloseForumTopicRequest : RequestBase<bool>, IChatTargetable
{
    /// <inheritdoc />
    [JsonProperty(Required = Required.Always)]
    public ChatId ChatId { get; }

    /// <summary>
    /// Unique identifier for the target message thread of the forum topic
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public int MessageThreadId { get; }

    /// <summary>
    /// Initializes a new request
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup</param>
    /// <param name="messageThreadId">Unique identifier for the target message thread of the forum topic</param>
    public CloseForumTopicRequest(ChatId chatId, int messageThreadId)
        : base("closeForumTopic")
    {
        ChatId = chatId;
        MessageThreadId = messageThreadId;
    }
}
