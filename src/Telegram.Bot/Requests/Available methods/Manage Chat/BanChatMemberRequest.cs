using JetBrains.Annotations;
using Telegram.Bot.Converters;
using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to ban a user in a group, a supergroup or a channel. In the case of supergroups
/// and channels, the user will not be able to return to the chat on their own using invite links,
/// etc., unless <see cref="UnbanChatMemberRequest">unbanned</see> first. The bot must be an
/// administrator in the chat for this to work and must have the appropriate admin rights.
/// Returns <see langword="true"/> on success.
/// </summary>
/// <param name="chatId">Unique identifier for the target chat or username of the target channel
/// (in the format <c>@channelusername</c>)
/// </param>
/// <param name="userId">Unique identifier of the target user</param>
[PublicAPI]
public class BanChatMemberRequest(ChatId chatId, long userId)
    : RequestBase<bool>("banChatMember"),
      IChatTargetable,
      IUserTargetable
{
    /// <inheritdoc />
    public ChatId ChatId { get; } = chatId;

    /// <inheritdoc />
    public long UserId { get; } = userId;

    /// <summary>
    /// Date when the user will be unbanned. If user is banned for more than 366 days or less
    /// than 30 seconds from the current time they are considered to be banned forever.
    /// Applied for supergroups and channels only.
    /// </summary>
    [JsonConverter(typeof(BanTimeUnixDateTimeConverter))]
    public DateTime? UntilDate { get; set; }

    /// <summary>
    /// Pass <see langword="true"/> to delete all messages from the chat for the user that is being removed. If
    /// <see langword="false"/>, the user will be able to see messages in the group that were sent before
    /// the user was removed. Always <see langword="true"/> for supergroups and channels.
    /// </summary>
    public bool? RevokeMessages { get; set; }
}
