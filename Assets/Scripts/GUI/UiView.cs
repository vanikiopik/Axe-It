using System;
using UnityEngine;

namespace GUI
{
    public abstract class UiView : MonoBehaviour
    {
        private Action OnUpdateAction { get; set; }
        public void SetUpdateAction(Action updateAction) => OnUpdateAction += updateAction;
        private void Update() => OnUpdateAction?.Invoke();
    }
}