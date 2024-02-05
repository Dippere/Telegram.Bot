namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a service message about a change in auto-delete timer settings.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class MessageAutoDeleteTimerChanged
{
    /// <summary>
    /// New auto-delete time for messages in the chat
    /// </summary>
    [DataMember(IsRequired = true)]
    public int MessageAutoDeleteTime { get; set; }
}
