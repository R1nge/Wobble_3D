﻿using UnityEngine;

namespace _Assets.Scripts.Game
{
    public class Location : MonoBehaviour
    {
        [SerializeField] private float sensitivity = 1.5f;
        [SerializeField] private float rotationMinLimitX,rotationMaxLimitX, rotationMinLimitZ, rotationMaxLimitZ;
        private Vector3 _look;

        private void FixedUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                _look += new Vector3(Input.GetAxis("Mouse Y") * sensitivity, 0, -Input.GetAxis("Mouse X") * sensitivity);
                _look.x = Mathf.Clamp(_look.x, -rotationMinLimitX, rotationMaxLimitX);
                _look.z = Mathf.Clamp(_look.z, -rotationMinLimitZ, rotationMaxLimitZ);
                transform.eulerAngles = _look;
            }
        }
    }
}