using UnityEngine;
using UnityEngine.UI;

namespace GUI.StartText
{
    [RequireComponent(typeof(Text))]
    public class StartTextView : UiView
    {
        public RectTransform StartText { get; private set; }
        private void Start() => StartText = GetComponent<RectTransform>();
    }
}
