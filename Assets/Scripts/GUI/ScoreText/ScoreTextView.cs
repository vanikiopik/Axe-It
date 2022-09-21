using UnityEngine;
using UnityEngine.UI;

namespace GUI.ScoreText
{
    [RequireComponent(typeof(Text))]
    public class ScoreTextView : UiView
    {
        public Text ScoreText { get; private set; }
        private void Start() => ScoreText = GetComponent<Text>();
    }
}
