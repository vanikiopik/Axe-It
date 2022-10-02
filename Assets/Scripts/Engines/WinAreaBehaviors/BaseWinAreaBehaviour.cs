using UnityEngine;

namespace Engines.WinAreaBehaviors
{
    public abstract class BaseWinAreaBehaviour
    {
        protected RectTransform Area { get; private set; }
        
        public void Start(RectTransform winArea) => Area = winArea;
        
        public virtual void ResetArea(float newAreaSize)
        {
            float sizeDeltaX = newAreaSize - Area.rect.width + Area.sizeDelta.x;
            Area.sizeDelta = new Vector2(sizeDeltaX, 0.0f);
            Area.localPosition = Vector3.right * Random.Range(-sizeDeltaX / 2.0f, sizeDeltaX / 2.0f);
        }

        public abstract void Update();
        public abstract void StopMove();
    }
}
