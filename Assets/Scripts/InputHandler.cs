using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour, IPointerDownHandler
{
    private Axe _axe;
    
    private void Start() => _axe = FindObjectOfType<Axe>(); 

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!IsOnButtonClick(eventData) && _axe.gameObject.activeSelf)
            _axe.TryAttack();
    }
    
    private bool IsOnButtonClick(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (var raycastResult in results)
            if (raycastResult.gameObject.GetComponent<Button>() != null)
                return true;

        return false;
    }
}
