using System.Collections.Generic;
using _Assets.Scripts.Game;
using TriInspector;
using UnityEngine;

namespace _Assets.Scripts.Services
{
    public class LevelDataService : MonoBehaviour
    {
        [SerializeField] private List<LevelData> levelData;
        private int _currentLevel;

        public LevelData CurrentData => levelData[_currentLevel];

        public void NextLevel()
        {
            if (_currentLevel < levelData.Count)
            {
                _currentLevel++;
            }
        }

        [Title("Add current level")]
        [Button]
        public void AddCurrentLevel()
        {
            var balls = FindObjectsOfType<Ball>();
            var holes = FindObjectsOfType<Tile>();
            
            var holePositions = new Vector3[holes.Length];
            for (int i = 0; i < holes.Length; i++)
            {
                holePositions[i] = holes[i].transform.position;
            }
            
            var ballPositions = new Vector3[balls.Length];
            for (int i = 0; i < balls.Length; i++)
            {
                ballPositions[i] = balls[i].transform.position;
            }
            
            var data = new LevelData(ballPositions, holePositions);
            levelData.Add(data);
        }
    }
}