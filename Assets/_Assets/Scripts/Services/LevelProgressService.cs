using _Assets.Scripts.Game;
using UnityEngine;

namespace _Assets.Scripts.Services
{
    public class LevelProgressService
    {
        private Tile[] _tiles;
        private int _currentTiles, _allTiles;

        public void Init(Tile[] tiles)
        {
            _tiles = tiles;
            _allTiles = _tiles.Length;
            _currentTiles = 0;
        }

        public void LockTile()
        {
            _currentTiles++;

            if (_currentTiles == _allTiles)
            {
                // TODO: Win
                Debug.LogError("Win");
            }
        }

        public void Reset()
        {
            _tiles = null;
            _allTiles = 0;
            _currentTiles = 0;
        }
    }
}