using System;
using UnityEngine;

namespace _Assets.Scripts.Services
{
    [Serializable]
    public struct LevelData
    {
        public GameObject location;
        public GameObject ball;
        public Vector3[] ballPositions;
        public GameObject hole;
        public Vector3[] holePositions;
    }
}