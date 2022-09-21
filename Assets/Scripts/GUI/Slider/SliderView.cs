using UnityEngine;

namespace GUI.Slider
{
    [RequireComponent(typeof(UnityEngine.UI.Slider))]
    public class SliderView : UiView
    {
        [field: SerializeField] public RectTransform FillArea { get; set; }
        [field: SerializeField] public RectTransform Handle { get; set; }
        public UnityEngine.UI.Slider Slider { get; private set; }
        private void Start() => Slider = GetComponent<UnityEngine.UI.Slider>();
    }
}
