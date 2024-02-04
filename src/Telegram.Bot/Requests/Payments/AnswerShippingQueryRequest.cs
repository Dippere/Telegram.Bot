﻿using System.Collections.Generic;
using Telegram.Bot.Types.Payments;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// If you sent an invoice requesting a shipping address and the parameter
/// <see cref="SendInvoiceRequest.IsFlexible"/> was specified, the Bot API will send an
/// <see cref="Types.Update"/> with a <see cref="Types.Update.ShippingQuery"/> field to the
/// bot. Use this method to reply to shipping queries. On success, <see langword="true"/> is returned.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
public class AnswerShippingQueryRequest : RequestBase<bool>
{
    /// <summary>
    /// Unique identifier for the query to be answered
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public string ShippingQueryId { get; }

    /// <summary>
    /// Specify <see langword="true"/> if delivery to the specified address is possible and <see langword="false"/>
    /// if there are any problems (for example, if delivery to the specified address is not possible)
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(Required = Required.Always)]
    #endif
    public bool Ok { get; }

    /// <summary>
    /// Required if <see cref="Ok"/> is <see langword="true"/>. An array of available shipping options.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public IEnumerable<ShippingOption>? ShippingOptions { get; }

    /// <summary>
    /// Required if <see cref="Ok"/> is <see langword="false"/>. Error message in human readable form that explains
    /// why it is impossible to complete the order (e.g. "Sorry, delivery to your desired address
    /// is unavailable'). Telegram will display this message to the user.
    /// </summary>
    #if !NET8_0_OR_GREATER
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    #endif
    public string? ErrorMessage { get; }

    /// <summary>
    /// Initializes a new failing answerShippingQuery request with error message
    /// </summary>
    /// <param name="shippingQueryId">Unique identifier for the query to be answered</param>
    /// <param name="errorMessage">Error message in human readable form</param>
    public AnswerShippingQueryRequest(string shippingQueryId, string errorMessage)
        : base("answerShippingQuery")
    {
        ShippingQueryId = shippingQueryId;
        Ok = false;
        ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Initializes a new successful answerShippingQuery request with shipping options
    /// </summary>
    /// <param name="shippingQueryId">Unique identifier for the query to be answered</param>
    /// <param name="shippingOptions">A JSON-serialized array of available shipping options</param>
    public AnswerShippingQueryRequest(
        string shippingQueryId,
        IEnumerable<ShippingOption> shippingOptions) : base("answerShippingQuery")
    {
        ShippingQueryId = shippingQueryId;
        Ok = true;
        ShippingOptions = shippingOptions;
    }
}
