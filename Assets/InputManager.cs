using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private AxeMovement _axe;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _axe.OnMouseButtonClicked(Random.Range(0, 2) == 0);
        }
    }
}
