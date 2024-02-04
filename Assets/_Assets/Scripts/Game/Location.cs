using UnityEngine;

namespace _Assets.Scripts.Game
{
    public class Location : MonoBehaviour
    {
        [SerializeField] private float sensitivity = 1.5f;
        [SerializeField] private float rotationLimitX, rotationLimitY;
        private Vector3 _look;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _look += new Vector3(-Input.GetAxis("Mouse Y") * sensitivity, Input.GetAxis("Mouse X") * sensitivity, 0);
                _look.x = Mathf.Clamp(_look.x, -rotationLimitX, rotationLimitX);
                _look.y = Mathf.Clamp(_look.y, -rotationLimitY, rotationLimitY);
                transform.eulerAngles = _look;
            }
        }
    }
}