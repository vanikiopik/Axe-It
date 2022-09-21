using UnityEngine;

namespace GUI.StartText
{
    [System.Serializable]
    public class StartTextController : UiController<StartTextView>
    {
        private float _time;

        protected override void Update()
        {
            _time += Time.deltaTime;
            float scaleValue = (Mathf.Sin(_time) + 3) / 4f;
            View.StartText.localScale = new Vector3(scaleValue, scaleValue, 1);
        }
    }
}