using UnityEngine;

namespace Wood
{
    public class WoodsBase : MonoBehaviour
    {
        [Header("Wood Objects")]
        [SerializeField] private ThrowableWood _leftWood;
        [SerializeField] private ThrowableWood _rightWood;

        [Header("Graphics Settings")]
        [SerializeField] private WoodsGraphics _graphics;
        [Range(0, 100)][SerializeField] private float _goldWoodPercent;
        
        [field: Header("Physics Settings")]
        [field: Min(0.0f)][field: SerializeField] public float ThrowingForce { get; private set; }
        [field: Min(0.0f)][field: SerializeField] public float ThrowDelay { get; private set; }

        public bool IsGold => _graphics.IsGoldMaterial;
        
        private void Start()
        {
            _graphics.Initialize(
                _leftWood.gameObject.GetComponent<MeshRenderer>(), 
                _rightWood.gameObject.GetComponent<MeshRenderer>());
            
            _leftWood.Initialize(this, Engines.MoveDirection.Left);
            _rightWood.Initialize(this, Engines.MoveDirection.Right);
        }
        
        public void ResetMaterials() => _graphics.SetRandomMaterials(_goldWoodPercent);
    }
}