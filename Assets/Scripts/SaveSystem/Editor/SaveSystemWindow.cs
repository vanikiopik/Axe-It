using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class SaveSystemWindow : EditorWindow
{
    static SaveSystemWindow _window;

    public static Dictionary<string, SaveSystem.ISaveItem> items;

    private static ReorderableList _list;
    private SaveSystem.ISaveItem _editItem;

    private Vector2 _itemsScroll;
    private Vector2 _itemScroll;

    [MenuItem("Save System/Editor", priority = 0)]
    public static void Init()
    {
        _window = GetWindow<SaveSystemWindow>();
        Load();
    }

    [MenuItem("Save System/Clear All Prefs", priority = 201)]
    public static void ClearAllPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Clear All Prefs");
    }

    [MenuItem("Save System/Clear Save", priority = 202)]
    public static void ClearSavePrefs()
    {
        PlayerPrefs.DeleteKey("Save");
        Debug.Log("Clear Pref \"Save\"");
    }

    [MenuItem ("Save System/Export", priority = 301)]
    public static void ExportSave()
    {
        var fileName = EditorUtility.SaveFilePanel("Export save", "", "Saves", "sav");
        if (fileName != "")
        {
            var content = PlayerPrefs.GetString("Save");
            File.WriteAllText(fileName, content);
        }
        else
        {
            EditorUtility.DisplayDialog("Ошибка", "Некорректный файл", "ОК");
        }
    }

    [MenuItem("Save System/Import", priority = 302)]
    public static void ImportSave()
    {
        var fileName = EditorUtility.OpenFilePanel("Import save", "", "sav");
        try
        {
            var content = File.ReadAllText(fileName);
            var save = JsonConvert.DeserializeObject<Dictionary<string, SaveSystem.ISaveItem>>(
                content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            if (save == null)
            {
                EditorUtility.DisplayDialog("Ошибка..", "Кажется файл битый", "ОК");
            }
            else
            {
                PlayerPrefs.SetString("Save", content);
                EditorUtility.DisplayDialog("Успешно", "Данные загружены", "ОК");
            }
        }
        catch { /* ignored */ }
    }

    private static void Load()
    {
        SaveSystem.Load();
        _list = null;
        items = SaveSystem.GetItems();
    }

    private static void Save() => SaveSystem.Save();

    private void OnGUI()
    {
        if (items == null) Load();
        if (_window == null) _window = GetWindow<SaveSystemWindow>();

        _window.minSize = new Vector2(600, 200);

        EditorGUILayout.BeginHorizontal("Box");
        if (GUILayout.Button("Load")) Load();
        if (GUILayout.Button("Save")) Save();
    
        EditorGUILayout.EndHorizontal();

        if (_list == null)
        {
            _list = new ReorderableList(
                items.Values.ToList(), 
                typeof(List<SaveSystem.ISaveItem>), 
                true, true, false, false);

            //Header
            _list.drawHeaderCallback = rect => EditorGUI.LabelField(rect, "Items");

            //List Items
            _list.drawElementCallback =
            (rect, index, _, _) =>
            {
                var target = items.Values.ToList()[index];
                rect.y += 2;
                var newRect = new Rect(rect.x, rect.y, rect.width, rect.height);
                EditorGUI.LabelField(new Rect(newRect.x, newRect.y, 300, EditorGUIUtility.singleLineHeight), target.Key);
            };

            //View Item
            _list.onSelectCallback = list => _editItem = items.Values.ToList()[list.index];
        }

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.BeginVertical(new GUIStyle { fixedWidth = 300 });
        _itemsScroll = EditorGUILayout.BeginScrollView(_itemsScroll);
        _list.DoLayoutList();
        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Fields");
        _itemScroll = EditorGUILayout.BeginScrollView(_itemScroll);

        if (_editItem != null)
        {
            var type = _editItem.GetType();

            DrawClass(_editItem);

            void DrawClass(object item)
            {
                if (item != null)
                {
                    var fields = item.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                    foreach (var field in fields)
                    {
                        var value = field.GetValue(item);
                        if (field.FieldType.IsArray)
                        {
                            if (value != null)
                            {
                                EditorGUILayout.BeginVertical("BOX");
                                EditorGUILayout.BeginFoldoutHeaderGroup(true, field.Name);
                                EditorGUILayout.EndFoldoutHeaderGroup();
                                foreach (var f in (Array)value) DrawClass(f);
                                EditorGUILayout.EndVertical();
                            }
                            else
                            {
                                EditorGUILayout.LabelField(field.Name, "NULL");
                            }
                        }
                        else
                        {
                            if (!field.FieldType.IsClass || field.FieldType == typeof(string))
                            {
                                Draw(field, item);
                            }
                            else
                            {
                                EditorGUILayout.BeginVertical("BOX");
                                EditorGUILayout.BeginFoldoutHeaderGroup(true, field.FieldType.Name);
                                EditorGUILayout.EndFoldoutHeaderGroup();
                                DrawClass(value);
                                EditorGUILayout.EndVertical();
                            }
                        }
                    }
                }
            }

            void Draw(FieldInfo field, object obj)
            {
                if (field.FieldType == typeof(long))
                {
                    var value = (long)field.GetValue(obj);
                    value = EditorGUILayout.LongField(field.Name, value);
                    field.SetValue(obj, value);
                }
                if (field.FieldType  == typeof(int))
                {
                    var value = (int)field.GetValue(obj);
                    value = EditorGUILayout.IntField(field.Name, value);
                    field.SetValue(obj, value);
                }
                if (field.FieldType == typeof(float))
                {
                    var value = (float)field.GetValue(obj);
                    value = EditorGUILayout.FloatField(field.Name, value);
                    field.SetValue(obj, value);
                }
                if (field.FieldType == typeof(string))
                {
                    var value = (string)field.GetValue(obj);
                    value = EditorGUILayout.TextField(field.Name, value);
                    field.SetValue(obj, value);
                }
                if (field.FieldType == typeof(double))
                {
                    var value = (double)field.GetValue(obj);
                    value = EditorGUILayout.DoubleField(field.Name, value);
                    field.SetValue(obj, value);
                }
                if (field.FieldType == typeof(bool))
                {
                    var value = (bool)field.GetValue(obj);
                    value = EditorGUILayout.Toggle(field.Name, value);
                    field.SetValue(obj, value);
                }
                if (field.FieldType == typeof(Color))
                {
                    var value = (Color)field.GetValue(obj);
                    value = EditorGUILayout.ColorField(field.Name, value);
                    field.SetValue(obj, value);
                }
                if (field.FieldType == typeof(Vector3))
                {
                    var value = (Vector3)field.GetValue(obj);
                    value = EditorGUILayout.Vector3Field(field.Name, value);
                    field.SetValue(obj, value);
                }
                if (field.FieldType == typeof(Vector2))
                {
                    var value = (Vector2)field.GetValue(obj);
                    value = EditorGUILayout.Vector2Field(field.Name, value);
                    field.SetValue(obj, value);
                }
                if (field.FieldType.IsEnum)
                {
                    var p = Enum.Parse(field.FieldType, field.GetValue(obj).ToString());
                    var value = EditorGUILayout.EnumPopup(field.FieldType.Name, (Enum)field.GetValue(obj));
                    field.SetValue(obj, value);
                }
            }

            if (GUILayout.Button("Delete Item"))
            {
                SaveSystem.Remove(_editItem.Key);
                _editItem = null;
                Load();
            }
        }
        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
    }
}