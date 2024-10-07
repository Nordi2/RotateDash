using Assets.Scripts.GamePlay.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Assets.Scripts.GamePlay
{
    public class SpikesController : IInitializable, IDisposable
    {
        private readonly ICharacterFacade _characterFacade;
        private readonly List<ObstacleObject> _spikesList;

        private List<ObstacleObject> _leftSpikes;
        private List<ObstacleObject> _rightSpikes;

        public SpikesController(ICharacterFacade characterFacade, List<ObstacleObject> spikesList)
        {
            _characterFacade = characterFacade;
            _spikesList = spikesList;
        }

        public void Initialize()
        {
            _leftSpikes = new List<ObstacleObject>(_spikesList.Where(obj => obj.TypeObstacle == TypeObstacle.SpikeLeft));
            _rightSpikes = new List<ObstacleObject>(_spikesList.Where(obj => obj.TypeObstacle == TypeObstacle.SpikeRight));

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