using Skins;
using UnityEngine;

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

    public void Load(Axe model)
    {
        _meshFilter.mesh = model.Mesh;
        _meshRenderer.materials = model.Materials.ToArray();
        _meshCollider.sharedMesh = model.Mesh;
    }

    public void PlayAnimation(bool isWoodAxed)
    {
        if (isWoodAxed)
            _animator.SetTrigger("HitAttack");
        else
            _animator.SetTrigger((Random.Range(0, 2) == 0 ? "Left" : "Right") + "MissAttack");
    }
}
