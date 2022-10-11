using GUI.GuiHandler;
using Skins;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(Animator))]
public class AxeEngine : MonoBehaviour
{
    private enum AxeState { Idle, Attack };
    private AxeState State { get; set; }
    
    private Gui _gui;
    private AxeGraphics _axeGraphics;

    public System.Action CameraShaking { get; set; }
    public bool IsWoodAxed { get; private set; }

    private void Awake()
    {
        _axeGraphics = new AxeGraphics(
            GetComponent<MeshFilter>(),
            GetComponent<MeshRenderer>(),
            GetComponent<MeshCollider>(),
            GetComponent<Animator>());
    }

    private void Start()
    {
        State = AxeState.Idle;
        _gui = Gui.Instance;
    }

    public void TryAttack()
    {
        if (State == AxeState.Attack) return;

        _gui.GameViewController.StopSliderAndArea();
        IsWoodAxed = _gui.GameViewController.IsHandleOverWinArea();
        _axeGraphics.PlayAnimation(IsWoodAxed);
    }

    public void LoadGraphics(Axe model) => _axeGraphics.Load(model);

    public void CameraShake() => CameraShaking?.Invoke();

    public void IncreaseScore() => ScoreCounter.IncreaseScore();

    public void ResetAfterAttack() => _gui.GameViewController.ResetSliderAndArea();

    public void EnableGameOver() => _gui.GameOverViewController.OnGameOverMenuEnable();
}