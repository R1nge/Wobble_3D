using _Assets.Scripts.Services.StateMachine;
using VContainer.Unity;

namespace _Assets.Scripts.Services
{
    public class GameWinService : IInitializable
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly LevelProgressService _levelProgressService;

        public GameWinService(GameStateMachine gameStateMachine, LevelProgressService levelProgressService)
        {
            _gameStateMachine = gameStateMachine;
            _levelProgressService = levelProgressService;
        }
        
        public void Initialize() => _levelProgressService.OnTileLocked += OnTileLocked;

        private void OnTileLocked(int current, int max)
        {
            if (current == max)
            {
                _gameStateMachine.SwitchState(GameStateType.Game);
            }
        }
    }
}