using Assets.Scripts.GamePlay.Character;
using System;
using System.Collections.Generic;
using Zenject;

namespace Assets.Scripts.GamePlay
{
    public class SpikesController : IInitializable, IDisposable
    {
        private readonly ICharacterFacade _characterFacade;
        private readonly List<ObstacleObject> _leftSpikes;
        private readonly List<ObstacleObject> _rightSpikes;

        public SpikesController(ICharacterFacade characterFacade, List<ObstacleObject> rightSpikes, List<ObstacleObject> leftSpikes)
        {
            _characterFacade = characterFacade;
            _rightSpikes = rightSpikes;
            _leftSpikes = leftSpikes;
        }

        public void Initialize()
        {
            _characterFacade.OnColliderWithWall += ActivateSpikes;

            EnableRightSpikes();
        }


        public void Dispose() =>
            _characterFacade.OnColliderWithWall -= ActivateSpikes;

        private void ActivateSpikes(TypeObstacle obstacle)
        {
            switch (obstacle)
            {
                case TypeObstacle.LeftWall:
                    EnableRightSpikes();
                    break;
                case TypeObstacle.RightWall:
                    EnableLeftSpikes();
                    break;
            }
        }

        private void EnableLeftSpikes()
        {
            DisableRightSpikes();
            for (int i = 0; i < 4; i++)
            {
                int random = UnityEngine.Random.Range(0, _leftSpikes.Count);
                _leftSpikes[random].gameObject.SetActive(true);
            }
        }

        private void EnableRightSpikes()
        {
            DisableLeftSpikes();
            for (int i = 0; i < 4; i++)
            {
                int random = UnityEngine.Random.Range(0, _rightSpikes.Count);
                _rightSpikes[random].gameObject.SetActive(true);
            }
        }

        private void DisableRightSpikes()
        {
            for (int i = 0; i < _rightSpikes.Count; i++)
                _rightSpikes[i].gameObject.SetActive(false);
        }

        private void DisableLeftSpikes()
        {
            for (int i = 0; i < _leftSpikes.Count; i++)
                _leftSpikes[i].gameObject.SetActive(false);
        }
    }
}