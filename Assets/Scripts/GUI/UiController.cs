using UnityEngine;

namespace GUI
{
    public abstract class UiController<T> where T : UiView
    {
        [field: SerializeField] public T View { get; set; }

        public abstract void SetActive(bool isActive);
        public virtual void Start() => View.OnUpdateAction += Update;
        protected virtual void Update() {}
    }
}
