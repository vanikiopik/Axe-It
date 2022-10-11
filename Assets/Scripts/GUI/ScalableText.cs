using UnityEngine;
using UnityEngine.UI;

namespace GUI
{
    [System.Serializable]
    public class ScalableText
    {
        [field: SerializeField] public Text Text { get; set; }
        [SerializeField] private float _scaleSpeed;
        [Range(0.0f, 1.0f)][SerializeField] private float _minScale;
        [Range(1.0f, 2.0f)][SerializeField] private float _maxScale;

        private float _time;
    
        public void Update()
        {
            _time += _scaleSpeed * Time.deltaTime;
            float scaleValue = (Mathf.Sin(_time) * (_maxScale - _minScale) + _maxScale + _minScale) / 2;
            Text.rectTransform.localScale = new Vector3(scaleValue, scaleValue, 1.0f);
        }
    }
}
