using UnityEngine;

namespace _Assets.Scripts.Services
{
    public class LevelDataService : MonoBehaviour
    {
        [SerializeField] private LevelData[] levelData;
        private int _currentLevel;

        public LevelData CurrentData => levelData[_currentLevel];

        public void NextLevel()
        {
            if (_currentLevel < levelData.Length)
            {
                _currentLevel++;
            }
        }
    }
}