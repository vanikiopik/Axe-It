using System;
using Newtonsoft.Json;
using UnityEngine;

public class Color32Converter : JsonConverter
{
    private readonly Type _type;
    public Color32Converter(Type type) => _type = type;

    public override bool CanConvert(Type objectType)
    {
        return _type == objectType;
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return null;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (value.GetType() != _type) return;
        
        var color = (Color32)value;
        writer.WriteStartObject();
        writer.WritePropertyName("R");
        writer.WriteValue(color.r);
        writer.WritePropertyName("G");
        writer.WriteValue(color.g);
        writer.WritePropertyName("B");
        writer.WriteValue(color.b);
        writer.WritePropertyName("A");
        writer.WriteValue(color.a);
        writer.WriteEndObject();
    }
}