using Zenject;
using UnityEngine;
using Assets.Scripts.GamePlay.Configs;

namespace Assets.Scripts.Infrastructure.Installers
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private LevelConfig _levelConfig;

        public override void InstallBindings()
        {
            Container
                .BindInstance(_levelConfig)
                .AsSingle();
        }
    }
}