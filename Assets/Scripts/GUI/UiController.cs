using UnityEngine;

namespace GUI
{
    public abstract class UiController<T> where T : UiView
    {
        [field: SerializeField] public T View { get; set; }
        protected GuiHandler Gui { get; private set; }

        public virtual void Start(GuiHandler gui)
        {
            Gui = gui;
            View.SetUpdateAction(Update);
        }

        protected virtual void Update() {}

        public void SetActive(bool isActive) => View.gameObject.SetActive(isActive);
    }
}