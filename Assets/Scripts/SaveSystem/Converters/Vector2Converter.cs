using UnityEngine;
using System;
using Newtonsoft.Json;

public class Vector2Converter : JsonConverter
{
    private readonly Type _type;
    public Vector2Converter(Type type) => _type = type;

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
        
        var vector = (Vector2)value;
        writer.WriteStartObject();
        writer.WritePropertyName("X");
        writer.WriteValue(vector.x);
        writer.WritePropertyName("Y");
        writer.WriteValue(vector.y);
        writer.WriteEndObject();
    }
}