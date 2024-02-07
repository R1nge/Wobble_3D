using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.StateMachine;
using _Assets.Scripts.Services.UIs;
using _Assets.Scripts.Services.UIs.StateMachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private LevelDataService levelDataService;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(levelDataService);

            builder.Register<LocationFactory>(Lifetime.Singleton);
            builder.Register<BallFactory>(Lifetime.Singleton);
            builder.Register<HoleFactory>(Lifetime.Singleton);
            
            builder.Register<UIStatesFactory>(Lifetime.Singleton);
            builder.Register<UIStateMachine>(Lifetime.Singleton);
            builder.Register<UIFactory>(Lifetime.Singleton);

            builder.Register<GameStatesFactory>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton);
        }
    }
}