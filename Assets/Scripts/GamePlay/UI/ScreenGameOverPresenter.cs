using Assets.Scripts.GamePlay.Character;
using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Scripts.GamePlay.UI
{
    public class ScreenGameOverPresenter : IInitializable, IDisposable
    {
        private const string MAIN_MENU_SCENE = "MainMenuScene";
        private const string GAME_PLAY_SCENE = "GamePlayScene";

        private readonly ICharacterFacade _characterFacade;
        private readonly ScoreBank _scoreBank;
        private readonly ScreenGameOverView _screenGameOverView;
        private readonly ScoreView _scoreView;

        public ScreenGameOverPresenter(ScoreBank scoreBank, ICharacterFacade characterFacade, ScreenGameOverView screenGameOverView, ScoreView scoreView)
        {
            _characterFacade = characterFacade;
            _scoreBank = scoreBank;
            _screenGameOverView = screenGameOverView;
            _scoreView = scoreView;
        }

        public void Initialize()
        {
            _screenGameOverView.MainMenuButton.AddListener(TransitionMainMenu);
            _screenGameOverView.RestartButton.AddListener(RestartGame);
            _characterFacade.OnDie += GameOverScreenActive;
        }

        public void Dispose()
        {
            _screenGameOverView.MainMenuButton.RemoveListener(TransitionMainMenu);
            _screenGameOverView.RestartButton.RemoveListener(RestartGame);
            _characterFacade.OnDie -= GameOverScreenActive;
        }

        private void TransitionMainMenu()
        {
            SceneManager.LoadScene(MAIN_MENU_SCENE);
        }

        private void GameOverScreenActive()
        {
            _screenGameOverView.SetPositionAnimations();
            _screenGameOverView.SetTextScore(_scoreBank.CurrentScore.ToString());
            _scoreView.DisableText();
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(GAME_PLAY_SCENE);
        }
    }
}