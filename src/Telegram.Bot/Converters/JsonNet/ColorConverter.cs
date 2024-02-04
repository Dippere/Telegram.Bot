﻿#if !NET7_0_OR_GREATER

using Newtonsoft.Json.Linq;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Converters;

internal class NullableColorConverter : JsonConverter<Color?>
{
    public override void WriteJson(JsonWriter writer, Color? value, JsonSerializer serializer)
    {
        if (value?.ToInt() is { } colorValue)
        {
            writer.WriteValue(colorValue);
        }
    }

    public override Color? ReadJson(
        JsonReader reader,
        Type objectType,
        Color? existingValue,
        bool hasExistingValue,
        JsonSerializer serializer)
    {
        var value = JToken.ReadFrom(reader).Value<int?>();
        return value is not null
            ? new Color(value.Value)
            : new Color?();
    }
}

internal class ColorConverter : JsonConverter<Color>
{
    public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer) =>
        writer.WriteValue(value.ToInt());

    public override Color ReadJson(
        JsonReader reader,
        Type objectType,
        Color existingValue,
        bool hasExistingValue,
        JsonSerializer serializer)
    {
        var value = JToken.ReadFrom(reader).Value<int>();
        return new(value);
    }
}

#endif