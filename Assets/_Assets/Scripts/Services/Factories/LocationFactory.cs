using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
    public class LocationFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly LevelDataService _levelDataService;

        private LocationFactory(IObjectResolver objectResolver, LevelDataService levelDataService)
        {
            _objectResolver = objectResolver;
            _levelDataService = levelDataService;
        }

        public GameObject Create() => _objectResolver.Instantiate(_levelDataService.CurrentData.location);
    }
}