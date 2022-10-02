using GUI;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AxeEngine : MonoBehaviour
{
    private enum AxeState { Idle, Attack };
    private AxeState State { get; set; }
    
    private GuiHandler _gui;
    private Animator _animator;
    private Wood[] _woods;
    private System.Action _cameraShaking;

    private int _woodsCount; // temp

    private void Start()
    {
        State = AxeState.Idle;
        _gui = GuiHandler.Instance;
        _animator = GetComponent<Animator>();
        _woods = FindObjectsOfType<Wood>();
        _cameraShaking += Camera.main.gameObject.GetComponent<CameraShake>().Shake;
    }

    public void TryAttack()
    {
        if (State == AxeState.Attack) return;

        _gui.GameViewController.StopSliderAndArea();
        
        if (_gui.GameViewController.IsHandleOverWinArea())
            _animator.SetTrigger("HitAttack");
        else
            _animator.SetTrigger((Random.Range(0, 2) == 0 ? "Left" : "Right") + "MissAttack");
    }

    public void CameraShake() => _cameraShaking?.Invoke();

    public void IncreaseScore() => ScoreCounter.IncreaseScore();

    public void ThrowWoods()
    {
        foreach (var wood in _woods) 
            StartCoroutine(wood.Throw(300.0f, 0.5f));
    }

    public void ResetAfterAttack() =>
        _gui.GameViewController.ResetSliderAndArea();

    public void EnableGameOver() =>
        _gui.GameOverViewController.OnGameOverMenuEnable();
}
