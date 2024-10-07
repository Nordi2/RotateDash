using Assets.Scripts.GamePlay.Character;
using Assets.Scripts.GamePlay.Configs;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Installers.GameObjectsInstaller
{
    public class CharacterMonoInstaller : MonoInstaller
    {
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private DetectedObstacleObserver _obstacleObserver;
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private CharacterFacade _characterFacade;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CharacterFacade>().FromInstance(_characterFacade).AsSingle();
            Container.BindInstance(_characterConfig).AsSingle();
            Container.BindInstance(_obstacleObserver).AsSingle();
            Container.BindInstance(_characterView).AsSingle();

            Container.BindInterfacesTo<CharacterVfxController>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterCollisionObstacleHandler>().AsSingle();
            Container.BindInterfacesTo<CharacterMovement>().AsSingle();
        }
    }
}