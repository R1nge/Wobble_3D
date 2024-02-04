using System.Collections;
using UnityEngine;

namespace _Assets.Scripts.Game
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Color lockedColor;
        private Vector3 _rotation;
        private Color _color;

        public void Lock()
        {
            rigidbody.isKinematic = true;
            StartCoroutine(LerpColor(1, meshRenderer.material.color, lockedColor));
            StartCoroutine(LerpRotation(1, transform.rotation.eulerAngles, Quaternion.identity.eulerAngles));
        }

        private IEnumerator LerpRotation(float lerpDuration, Vector3 currentRotation, Vector3 desiredRotation)
        {
            float timeElapsed = 0;
            while (timeElapsed < lerpDuration)
            {
                _rotation = Vector3.Lerp(currentRotation, desiredRotation, timeElapsed / lerpDuration);
                transform.rotation = Quaternion.Euler(_rotation);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            transform.rotation = Quaternion.Euler(desiredRotation);
        }

        private IEnumerator LerpColor(float lerpDuration, Color currentColor, Color desiredColor)
        {
            float timeElapsed = 0;
            while (timeElapsed < lerpDuration)
            {
                _color = Color.Lerp(currentColor, desiredColor, timeElapsed / lerpDuration);
                meshRenderer.material.color = _color;
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            meshRenderer.material.color = desiredColor;
        }
    }
}