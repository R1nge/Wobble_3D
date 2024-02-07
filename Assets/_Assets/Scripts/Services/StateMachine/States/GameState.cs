using _Assets.Scripts.Services.Factories;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IGameState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly LevelDataService _levelDataService;
        private readonly LocationFactory _locationFactory;
        private readonly BallFactory _ballFactory;
        private readonly LevelProgressService _levelProgressService;

        public GameState(GameStateMachine stateMachine, LevelDataService levelDataService, LocationFactory locationFactory, BallFactory ballFactory, LevelProgressService levelProgressService)
        {
            _stateMachine = stateMachine;
            _levelDataService = levelDataService;
            _locationFactory = locationFactory;
            _ballFactory = ballFactory;
            _levelProgressService = levelProgressService;
        }

        public void Enter()
        {
            _locationFactory.Create();

            for (int i = 0; i < _levelDataService.CurrentData.ballPositions.Length; i++)
            {
                var ball = _ballFactory.Create();
                ball.transform.position = _levelDataService.CurrentData.ballPositions[i];
            }
        }

        public void Exit()
        {
            //3 State ( Init, one when the game is started, and another when the player wins)
            _levelDataService.NextLevel();
            _levelProgressService.Reset();
        }
    }
}