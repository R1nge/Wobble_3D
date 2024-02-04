using System;
using TriInspector;
using UnityEngine;

namespace _Assets.Scripts.Services
{
    [Serializable]
    public struct LevelData
    {
        [Required]
        public GameObject location;
        [Required]
        public GameObject ball;
        public Vector3[] ballPositions;
        [Required]
        public GameObject hole;
        public Vector3[] holePositions;

        public LevelData(Vector3[] ballPositions, Vector3[] holePositions)
        {
            location = null;
            ball = null;
            hole = null;
            this.ballPositions = ballPositions;
            this.holePositions = holePositions;
        }
    }
}