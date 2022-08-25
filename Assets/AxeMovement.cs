using System.Collections;
using DG.Tweening;
using UnityEngine;

public class AxeMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _leftWood;
    [SerializeField] private Rigidbody _rightWood;
    
    private bool _isAttacking;

    public void OnMouseButtonClicked(bool isWoodAxed)
    {
        if (!_isAttacking)
        {
            StartCoroutine(Attack(isWoodAxed));
        }
    }

    private IEnumerator Attack(bool isAxed)
    {
        _isAttacking = true;

        int yRotation = 15 * (Random.Range(0, 2) == 0 ? 1 : -1);
        transform.DOLocalRotate(transform.rotation.eulerAngles + new Vector3(-20, isAxed ? 0 : yRotation, 0), 0.3f);
        yield return new WaitForSeconds(0.3f);
        transform.DOLocalRotate(transform.rotation.eulerAngles + new Vector3(70, 0, 0), 0.2f);
        yield return new WaitForSeconds(0.2f);

        if (isAxed)
        {
            
        }

        transform.DOLocalRotate(transform.rotation.eulerAngles + new Vector3(-50, isAxed ? 0 : -yRotation, 0), 0.5f);
        yield return new WaitForSeconds(0.5f);

        _isAttacking = false;
    }
}