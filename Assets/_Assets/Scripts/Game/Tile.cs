using System.Collections;
using UnityEngine;

namespace _Assets.Scripts.Game
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
        [SerializeField] private BoxCollider whole;
        private Vector3 _wholeStartSize;
        private readonly YieldInstruction _wait = new WaitForSeconds(.005f);

        private void Awake() => _wholeStartSize = whole.size;

        private void Update()
        {
            var blendShapeWeight = 1f - skinnedMeshRenderer.GetBlendShapeWeight(0) / 100f;
            whole.size = blendShapeWeight <= 0 ? Vector3.zero : _wholeStartSize * blendShapeWeight;
        }

        public void Open() => StartCoroutine(Open_C());

        private IEnumerator Open_C()
        {
            while (skinnedMeshRenderer.GetBlendShapeWeight(0) / 100 < 1)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(0, skinnedMeshRenderer.GetBlendShapeWeight(0) + 1);
                yield return _wait;
            }
        }

        public void Close() => StartCoroutine(Close_C());

        private IEnumerator Close_C()
        {
            while (skinnedMeshRenderer.GetBlendShapeWeight(0) / 100 < 1)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(0, skinnedMeshRenderer.GetBlendShapeWeight(0) + 1);
                yield return _wait;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Ball ball))
            {
                ball.Lock();
                ball.transform.parent = transform;
            }
        }
    }
}