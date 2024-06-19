﻿namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to create a topic in a forum supergroup chat. The bot must be an administrator in the chat for this to work and must have the <em>CanManageTopics</em> administrator rights.<para>Returns: Information about the created topic as a <see cref="ForumTopic"/> object.</para>
/// </summary>
public partial class CreateForumTopicRequest : RequestBase<ForumTopic>, IChatTargetable
{
    /// <summary>
    /// Unique identifier for the target chat or username of the target supergroup (in the format <c>@supergroupusername</c>)
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required ChatId ChatId { get; set; }

    /// <summary>
    /// Topic name, 1-128 characters
    /// </summary>
    [JsonRequired]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string Name { get; set; }

    /// <summary>
    /// Color of the topic icon in RGB format. Currently, must be one of 7322096 (0x6FB9F0), 16766590 (0xFFD67E), 13338331 (0xCB86DB), 9367192 (0x8EEE98), 16749490 (0xFF93B2), or 16478047 (0xFB6F5F)
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Color? IconColor { get; set; }

    /// <summary>
    /// Unique identifier of the custom emoji shown as the topic icon. Use <see cref="TelegramBotClientExtensions.GetForumTopicIconStickersAsync">GetForumTopicIconStickers</see> to get all allowed custom emoji identifiers.
    /// </summary>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? IconCustomEmojiId { get; set; }

    /// <summary>
    /// Initializes an instance of <see cref="CreateForumTopicRequest"/>
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup (in the format <c>@supergroupusername</c>)</param>
    /// <param name="name">Topic name, 1-128 characters</param>
    [Obsolete("Use parameterless constructor with required properties")]
    [SetsRequiredMembers]
    public CreateForumTopicRequest(ChatId chatId, string name)
        : this()
    {
        ChatId = chatId;
        Name = name;
    }

    /// <summary>
    /// Instantiates a new <see cref="CreateForumTopicRequest"/>
    /// </summary>
    public CreateForumTopicRequest()
        : base("createForumTopic")
    { }
}
