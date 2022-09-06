using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreTextController : MonoBehaviour
{
    private Text _view;

    private void Start() => _view = GetComponent<Text>();

    public void Set(string text) => _view.text = text;
    public void Clear() => _view.text = string.Empty;
}
