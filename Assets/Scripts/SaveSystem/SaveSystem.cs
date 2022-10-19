using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    public abstract class ISaveItem
    {
        public string Key { get; set; }
    }

    private class SaveItem<T> : ISaveItem
    {
        public T item;
    }

    private static Dictionary<string, ISaveItem> _items;

    private static bool _isInit;

    private static void Init()
    {
        if (_isInit) return;
        
        _isInit = true;
        _items = new Dictionary<string, ISaveItem>();
        Load();
    }

    public static Dictionary<string, ISaveItem> GetItems()
    {
        return _items;
    }

    public static void Load()
    {
        var json = PlayerPrefs.GetString("Save");
        var save = JsonConvert.DeserializeObject<Dictionary<string, ISaveItem>>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        if (save != null) _items = save;
    }

    public static void Save()
    {
        if (!_isInit) Init();
        var json = JsonConvert.SerializeObject(_items, new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All,
            Converters = new List<JsonConverter>
            {
                new ColorConverter(typeof(Color)),
                new Color32Converter(typeof(Color32)),
                new Vector2Converter(typeof(Vector2)),
                new Vector3Converter(typeof(Vector3))
            }
        });
        PlayerPrefs.SetString("Save", json);
    }

    public static void Set<T>(string key, T item, bool commitSave = true)
    {
        if (!_isInit) Init();
        if (!_items.ContainsKey(key)) _items.Add(key, null);
        _items[key] = new SaveItem<T> { item = item, Key = key };
        if (commitSave) Save();
    }

    public static void Remove(string key)
    {
        if (!_isInit) Init();
        if (_items.ContainsKey(key)) _items.Remove(key);
        Save();
    }

    public static T Get<T>(string key)
    {
        if (!_isInit) Init();
        var result = default(T);
        if (_items.ContainsKey(key))
        {
            try
            {
                result = (_items[key] as SaveItem<T>).item;
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Error key: {key}: {e}");
            }
        }
        return result;
    }
}