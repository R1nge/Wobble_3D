using UnityEngine;

namespace _Assets.Scripts.Game
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
        [SerializeField] private BoxCollider whole;
        private Vector3 _wholeStartSize;

        private void Awake() => _wholeStartSize = whole.size;

        private void Update()
        {
            var blendShapeWeight = 1f - skinnedMeshRenderer.GetBlendShapeWeight(0) / 100f;
            whole.size = blendShapeWeight <= 0 ? Vector3.zero : _wholeStartSize * blendShapeWeight;
        }
    }
}