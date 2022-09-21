using System;
using IEnumerator = System.Collections.IEnumerator;
using Random = UnityEngine.Random;
using DG.Tweening;
using GUI;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] private Wood[] _woods;
    [SerializeField] private float _woodThrowingForce;

    private bool _isAttacking;
    private int _woodsCount;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0) || _isAttacking) return;

        GuiHandler.Instance.SliderController.StopSliderMove();
        StartCoroutine(Attack(GuiHandler.Instance.SliderController.IsHandleOverWinningArea()));
    }

    private IEnumerator Attack(bool isWoodAxed)
    {
        _isAttacking = true;

        int yRotation = isWoodAxed ? 0 : Random.Range(0, 2) == 0 ? 15 : -15;
        transform.DOLocalRotate(transform.rotation.eulerAngles + new Vector3(-20, yRotation, 0), 0.3f);
        yield return new WaitForSeconds(0.3f);

        if (!isWoodAxed) FindObjectOfType<CameraShake>().Shake();

        transform.DOLocalRotate(transform.rotation.eulerAngles + new Vector3(70, 0, 0), 0.2f);
        yield return new WaitForSeconds(0.2f);

        if (isWoodAxed)
        {
            GuiHandler.Instance.ScoreTextController.Set($"Score: {++_woodsCount}");

            foreach (var wood in _woods)
                StartCoroutine(wood.Throw(_woodThrowingForce, 1.0f));
        }

        transform.DOLocalRotate(transform.rotation.eulerAngles + new Vector3(-50, -yRotation, 0), 0.5f);
        yield return new WaitForSeconds(1.0f);

        GuiHandler.Instance.SliderController.ResetSlider();
        GuiHandler.Instance.SliderController.ResetFillArea();
        _isAttacking = false;
    }

    private void Start()
    {
        int[] arr = new int[] {5, 3, 2, 4, 1};
        Array.Sort(arr);
        foreach (var i in arr)
        {
            Debug.Log(i);
        }
    }


    // ______________________________________________________________________________________________________________
    /*private void Start() => enabled = false;

    public void Hide()
    {
        enabled = false;
        transform.DOLocalRotate(transform.rotation.eulerAngles + new Vector3(60, 0, 0), 0.6f);
    }

    public void Foo()
    {
        transform.DOLocalRotate(transform.rotation.eulerAngles + new Vector3(-60, 0, 0), 0.6f);
        enabled = true;
    }*/
}