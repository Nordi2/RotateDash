using Zenject;
using UnityEngine;
using Assets.Scripts.GamePlay.UI;

namespace Assets.Scripts.Infrastructure.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private ScoreView          _scoreView;
        [SerializeField] private ScreenGameOverView _screeGameOverScreen;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScoreBank>().AsSingle().NonLazy();
            Container.BindInterfacesTo<ScreenGameOverPresenter>().AsSingle().WithArguments(_screeGameOverScreen, _scoreView);
            Container.BindInterfacesTo<ScorePresenter>().AsSingle().WithArguments(_scoreView);
        }
    }
}