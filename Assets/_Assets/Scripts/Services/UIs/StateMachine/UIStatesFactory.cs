using _Assets.Scripts.Services.UIs.StateMachine.States;

namespace _Assets.Scripts.Services.UIs.StateMachine
{
    public class UIStatesFactory
    {
        public IUIState CreateGameState(UIStateMachine uiStateMachine)
        {
            return new UIGameState();
        }
    }
}