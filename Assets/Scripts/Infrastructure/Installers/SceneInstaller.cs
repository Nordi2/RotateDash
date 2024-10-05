using Zenject;
using UnityEngine;
using Assets.Scripts.GamePlay.Configs;
using Assets.Scripts.GamePlay.Character;

namespace Assets.Scripts.Infrastructure.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private CharacterConfig _characterConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_characterConfig).AsSingle();
            Container.Bind<DetectedWallObserver>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CharacterView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<CharacterMovement>().AsSingle();
        }
    }
}