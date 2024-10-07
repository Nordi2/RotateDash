using Assets.Scripts.GamePlay.Character;
using System;
using Zenject;

namespace Assets.Scripts.GamePlay.UI
{
    public class ScreenGameOverPresenter : IInitializable, IDisposable
    {
        private readonly ICharacterFacade _characterFacade;
        private readonly ScoreBank _scoreBank;

        public ScreenGameOverPresenter(ScoreBank scoreBank, ICharacterFacade characterFacade)
        {
            _characterFacade = characterFacade;
            _scoreBank = scoreBank;
        }

        public void Initialize() =>
            _characterFacade.OnDie += GameOverScreenActive;

        public void Dispose() =>
            _characterFacade.OnDie -= GameOverScreenActive;

        private void GameOverScreenActive()
        {

        }
    }
}