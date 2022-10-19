using GUI.GuiHandler;
using Skins;
using UnityEngine;

namespace Axe
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshCollider))]
    [RequireComponent(typeof(Animator))]
    public class AxeEngine : MonoBehaviour
    {
        public enum AxeState { Idle, HitAttack, MissAttack }
        
        [field: Min(0)][field: SerializeField] private int _goldWoodReward;
    
        private Gui _gui;
        private AxeGraphics _axeGraphics;

        public System.Action CameraShaking { get; set; }
        public AxeState State { get; private set; }

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
            if (State != AxeState.Idle) return;

            _gui.GameViewController.StopSliderAndArea();
            State = _gui.GameViewController.IsHandleOverWinArea() ? AxeState.HitAttack : AxeState.MissAttack;
            _axeGraphics.PlayAnimation(State);
        }

        public void LoadGraphics(AxeSkin model) => _axeGraphics.Load(model);

        public void GoldWoodAxed() => _gui.MoneyCounter.AddCoins(_goldWoodReward);

        public void CameraShake() => CameraShaking?.Invoke();

        public void IncreaseScore() => _gui.ScoreCounter.IncreaseScore();

        public void ResetAfterAttack() => _gui.GameViewController.ResetSliderAndArea();

        public void EnableGameOver() => _gui.GameOverViewController.OnGameOverMenuEnable();
    }
}