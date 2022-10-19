using UnityEngine;
using UnityEngine.Events;

namespace GUI.GuiHandler
{
    public abstract class UiController<T> where T : UiView
    {
        [field: SerializeField] public T View { get; private set; }
        
        protected Gui Gui { get; private set; }

        public virtual void Initialize(Gui gui, UnityEvent onUpdate)
        {
            Gui = gui;
            onUpdate.AddListener(Update);
        }

        protected virtual void Update() {}

        public void SetActive(bool isActive) => View.gameObject.SetActive(isActive);
    }
}