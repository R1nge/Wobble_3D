using UnityEngine;

namespace _Assets.Scripts.Game
{
    public class Hole : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Ball ball))
            {
                ball.Lock();
            }
        }
    }
}