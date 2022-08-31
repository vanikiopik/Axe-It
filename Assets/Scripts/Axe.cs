using IEnumerator = System.Collections.IEnumerator;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Axe : MonoBehaviour
{
    [SerializeField] private SliderController _slider;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Wood[] _woods;
    [SerializeField] private float _woodThrowingForce;

    private bool _isAttacking;
    private int _woodsCount;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_isAttacking)
            {
                _slider.enabled = false;
                StartCoroutine(Attack(_slider.IsHandleOverWinningArea()));
            }
        }
    }

    private IEnumerator Attack(bool isWoodAxed)
    {
        _isAttacking = true;

        int yRotation = isWoodAxed ? 0 : Random.Range(0, 2) == 0 ? 15 : -15;
        transform.DOLocalRotate(transform.rotation.eulerAngles + new Vector3(-20, yRotation, 0), 0.3f);
        yield return new WaitForSeconds(0.3f);

        transform.DOLocalRotate(transform.rotation.eulerAngles + new Vector3(70, 0, 0), 0.2f);
        yield return new WaitForSeconds(0.2f);

        if (isWoodAxed)
        {
            _scoreText.text = $"Score: {++_woodsCount}";

            foreach (var wood in _woods)
                StartCoroutine(wood.Throw(_woodThrowingForce));
        }

        transform.DOLocalRotate(transform.rotation.eulerAngles + new Vector3(-50, -yRotation, 0), 0.5f);
        yield return new WaitForSeconds(1.0f);

        _slider.SetToStart();
        _isAttacking = false;
    }
}