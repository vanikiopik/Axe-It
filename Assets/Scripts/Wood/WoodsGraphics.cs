using UnityEngine;

namespace Wood
{
    [System.Serializable]
    public class WoodsGraphics
    {
        [field: SerializeField] public Material[] DefaultMaterials { get; private set; }
        [field: SerializeField] public Material[] GoldMaterials { get; private set; }

        private Material[] _currentMaterials;
        private MeshRenderer _leftWoodRenderer;
        private MeshRenderer _rightWoodRenderer;

        public bool IsGoldMaterial => _currentMaterials == GoldMaterials;
        
        public void Initialize(MeshRenderer leftWoodRenderer, MeshRenderer rightWoodRenderer)
        {
            _leftWoodRenderer = leftWoodRenderer;
            _rightWoodRenderer = rightWoodRenderer;
            SetDefaultMaterials();
        }
        
        public void SetRandomMaterials(float percent)
        {
            if (Random.Range(0.0f, 100.0f) <= percent)
                SetGoldMaterials();
            else
                SetDefaultMaterials();
        }

        private void SetDefaultMaterials()
        {
            _leftWoodRenderer.materials = DefaultMaterials;
            _rightWoodRenderer.materials = DefaultMaterials;
            _currentMaterials = DefaultMaterials;
        }

        private void SetGoldMaterials()
        {
            _leftWoodRenderer.materials = GoldMaterials;
            _rightWoodRenderer.materials = GoldMaterials;
            _currentMaterials = GoldMaterials;
        }
    }
}