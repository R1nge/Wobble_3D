using _Assets.Scripts.Services;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Game
{
    public class Location : MonoBehaviour
    {
        [SerializeField] private float sensitivity = .5f;
        [SerializeField] private float rotationMinLimitX = 25, rotationMaxLimitX = 15, rotationMinLimitZ = 20, rotationMaxLimitZ = 20;
        [SerializeField] private Tile[] tiles;
        private Vector3 _look;
        [Inject] private LevelProgressService _levelProgressService;

        private void Start()
        {
            _levelProgressService.Init(tiles);
            
            foreach (var tile in tiles)
            {
                tile.Open();
            }
        }

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