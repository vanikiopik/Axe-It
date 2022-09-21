using System;
using UnityEngine;

namespace GUI
{
    public abstract class UiView : MonoBehaviour
    {
        public Action OnUpdateAction { get; set; }
        private void Update() => OnUpdateAction?.Invoke();
    }
}