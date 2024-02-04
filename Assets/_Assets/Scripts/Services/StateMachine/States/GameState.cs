using _Assets.Scripts.Services.Factories;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IGameState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly LevelDataService _levelDataService;
        private readonly LocationFactory _locationFactory;
        private readonly BallFactory _ballFactory;
        private readonly HoleFactory _holeFactory;

        public GameState(GameStateMachine stateMachine, LevelDataService levelDataService, LocationFactory locationFactory, BallFactory ballFactory, HoleFactory holeFactory)
        {
            _stateMachine = stateMachine;
            _levelDataService = levelDataService;
            _locationFactory = locationFactory;
            _ballFactory = ballFactory;
            _holeFactory = holeFactory;
        }

        public void Enter()
        {
            _locationFactory.Create();

            for (int i = 0; i < _levelDataService.CurrentData.ballPositions.Length; i++)
            {
                var ball = _ballFactory.Create();
                ball.transform.position = _levelDataService.CurrentData.ballPositions[i];
            }

            for (int i = 0; i < _levelDataService.CurrentData.holePositions.Length; i++)
            {
                var hole = _holeFactory.Create();
                hole.transform.position = _levelDataService.CurrentData.holePositions[i];
            }
        }

        public void Exit()
        {
        }
    }
}