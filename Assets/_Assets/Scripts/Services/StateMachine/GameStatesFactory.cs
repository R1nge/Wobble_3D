using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.StateMachine.States;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        private readonly LevelDataService _levelDataService;
        private readonly LocationFactory _locationFactory;
        private readonly BallFactory _ballFactory;
        private readonly HoleFactory _holeFactory;

        private GameStatesFactory(LevelDataService levelDataService, LocationFactory locationFactory, BallFactory ballFactory, HoleFactory holeFactory)
        {
            _levelDataService = levelDataService;
            _locationFactory = locationFactory;
            _ballFactory = ballFactory;
            _holeFactory = holeFactory;
        }

        public IGameState CreateGameState(GameStateMachine stateMachine)
        {
            return new GameState(stateMachine, _levelDataService, _locationFactory, _ballFactory, _holeFactory);
        }
    }
}