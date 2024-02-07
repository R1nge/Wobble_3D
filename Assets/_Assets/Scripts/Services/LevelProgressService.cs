using System;
using _Assets.Scripts.Game;
using UnityEngine;

namespace _Assets.Scripts.Services
{
    public class LevelProgressService
    {
        public event Action<int, int> OnTileLocked;
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
            OnTileLocked?.Invoke(_currentTiles, _allTiles);
        }

        public void Reset()
        {
            Debug.LogError("Reset");
            _tiles = null;
            _allTiles = 0;
            _currentTiles = 0;
        }
    }
}