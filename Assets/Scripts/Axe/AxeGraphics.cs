using UnityEngine;

namespace Axe
{
    public class AxeGraphics
    {
        private readonly MeshFilter _meshFilter;
        private readonly MeshRenderer _meshRenderer;
        private readonly MeshCollider _meshCollider;
        private readonly Animator _animator;

        public AxeGraphics(MeshFilter meshFilter, MeshRenderer meshRenderer, MeshCollider meshCollider, Animator animator)
        {
            _meshFilter = meshFilter;
            _meshRenderer = meshRenderer;
            _meshCollider = meshCollider;
            _animator = animator;
        }

        public void Load(Skins.AxeSkin model)
        {
            _meshFilter.mesh = model.Mesh;
            _meshRenderer.materials = model.Materials.ToArray();
            _meshCollider.sharedMesh = model.Mesh;
        }

        public void PlayAnimation(AxeEngine.AxeState axeState)
        {
            if (axeState == AxeEngine.AxeState.Idle) return;
            _animator.SetTrigger(axeState switch
            {
                AxeEngine.AxeState.HitAttack => "HitAttack",
                AxeEngine.AxeState.MissAttack => (Random.Range(0, 2) == 0 ? "Left" : "Right") + "MissAttack",
                _ => ""
            });
        }
    }
}
