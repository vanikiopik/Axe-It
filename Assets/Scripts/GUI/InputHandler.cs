using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GUI
{
    [RequireComponent(typeof(GuiHandler))]
    public class InputHandler : MonoBehaviour, IPointerDownHandler
    {
        private GuiHandler _gui;

        private void Start() => _gui = GetComponent<GuiHandler>();

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!IsButtonClick(eventData) && _gui.AxeEngine.enabled) 
                _gui.AxeEngine.TryAttack();
        }
    
        private static bool IsButtonClick(PointerEventData eventData)
        {
            var results = new System.Collections.Generic.List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            foreach (var raycastResult in results)
                if (raycastResult.gameObject.GetComponent<Button>() != null)
                    return true;

            return false;
        }
    }
}