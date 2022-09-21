using UnityEngine;
using UnityEngine.UI;

namespace GUI.ScoreText
{
    [System.Serializable]
    [RequireComponent(typeof(Text))]
    public class ScoreTextController : UiController<ScoreTextView>
    {
        public void Set(string text) => View.ScoreText.text = text;
        public void Clear() => View.ScoreText.text = string.Empty;
    }
}
