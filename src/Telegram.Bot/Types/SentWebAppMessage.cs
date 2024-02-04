﻿namespace Telegram.Bot.Types;

/// <summary>
/// Contains information about an inline message sent by a
/// <a href="https://core.telegram.org/bots/webapps">Web App</a> on behalf of a user.
/// </summary>
#if !NET7_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class SentWebAppMessage
{
    /// <summary>
    /// Optional. Identifier of the sent inline message. Available only if there is an inline keyboard attached
    /// to the message.
    /// </summary>
    #if !NET7_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public string? InlineMessageId { get; set; }
}
