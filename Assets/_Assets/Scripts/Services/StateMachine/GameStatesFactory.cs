using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.StateMachine.States;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        private readonly LevelDataService _levelDataService;
        private readonly LocationFactory _locationFactory;
        private readonly BallFactory _ballFactory;
        private readonly LevelProgressService _levelProgressService;

        private GameStatesFactory(LevelDataService levelDataService, LocationFactory locationFactory, BallFactory ballFactory, LevelProgressService levelProgressService)
        {
            _levelDataService = levelDataService;
            _locationFactory = locationFactory;
            _ballFactory = ballFactory;
            _levelProgressService = levelProgressService;
        }

        public IGameState CreateGameState(GameStateMachine stateMachine)
        {
            return new GameState(stateMachine, _levelDataService, _locationFactory, _ballFactory, _levelProgressService);
        }
    }
}