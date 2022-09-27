using IEnumerator = System.Collections.IEnumerator;
using Random = UnityEngine.Random;
using GUI;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Axe : MonoBehaviour
{
    [SerializeField] private float _woodThrowingForce;

    private CameraShake _cameraShake;
    private Animator _animator;
    private GuiHandler _gui;
    private Wood[] _woods;
    private bool _isAttacking;
    private int _woodsCount; // temp

    private void Start()
    {
        _gui = GuiHandler.Instance;
        _woods = FindObjectsOfType<Wood>();
        _cameraShake = FindObjectOfType<CameraShake>();
        _animator = GetComponent<Animator>();
    }

    public void TryAttack()
    {
        if (_isAttacking) return;
        
        _gui.GameViewController.Engine.StopSliderMove();
        bool isAxed = _gui.GameViewController.Engine.IsHandleOverWinningArea();
        StartCoroutine(isAxed ? HitAttack() : MissAttack());
    }

    private IEnumerator HitAttack()
    {
        _isAttacking = true;

        _animator.SetTrigger("HitAttack");
        yield return new WaitForSeconds(0.5f);

        _gui.GameViewController.SetScoreText(++_woodsCount); // temp
        _gui.PauseMenuViewController.SetScoreInfoText(_woodsCount, 9999); // temp

        foreach (var wood in _woods) 
            StartCoroutine(wood.Throw(_woodThrowingForce, 1.0f));
        
        yield return new WaitForSeconds(1.0f);

        _gui.GameViewController.Engine.ResetSliderAndArea();
        _gui.GameViewController.Engine.IncreaseSliderSpeed();
        _isAttacking = false;
    }

    private IEnumerator MissAttack()
    {
        _isAttacking = true;
        
        _animator.SetTrigger((Random.Range(0, 2) == 0 ? "Left" : "Right") + "MissAttack");
        yield return new WaitForSeconds(0.3f);
        
        _cameraShake.Shake();
        yield return new WaitForSeconds(0.7f);

        _gui.GameViewController.Engine.ResetSliderAndArea();
        _gui.GameOverViewController.OnGameOverMenuEnable();
        _isAttacking = false;
    }
}