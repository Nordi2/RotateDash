using Assets.Scripts.GamePlay.Character;
using Zenject;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.GamePlay;

namespace Assets.Scripts.Infrastructure.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private List<ObstacleObject> _spikesList;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CharacterFacade>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<SpikesController>().AsSingle().WithArguments(_spikesList).NonLazy();
        }
    }
}