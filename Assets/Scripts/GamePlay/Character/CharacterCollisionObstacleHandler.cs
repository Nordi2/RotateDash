using DG.Tweening;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.GamePlay.Character
{
    public class CharacterCollisionObstacleHandler : IInitializable, IDisposable
    {
        private readonly ICharacterFacade _characterFacade;
        private readonly DetectedObstacleObserver _observerCollision;

        public CharacterCollisionObstacleHandler(ICharacterFacade characterFacade, DetectedObstacleObserver observerCollision)
        {
            _characterFacade = characterFacade;
            _observerCollision = observerCollision;
        }

        public void Initialize() =>
            _observerCollision.TriggerEnter += DetectedObstacle;

        public void Dispose() =>
            _observerCollision.TriggerEnter -= DetectedObstacle;

        private void DetectedObstacle(Collision2D obstacle)
        {
            if (obstacle.gameObject.GetComponent<ObstacleObject>() is null)
                return;

            TypeObstacle typeObstacle = obstacle.gameObject.GetComponent<ObstacleObject>().TypeObstacle;

            switch (typeObstacle)
            {
                case TypeObstacle.None:
                    throw new ArgumentException("The type of obstacle is not selected");
                case TypeObstacle.UpWall:
                    DoCameraShake();
                    break;
                case TypeObstacle.BottonWall:
                    DoCameraShake();
                    break;
                case TypeObstacle.LeftWall:
                    DoCameraShake();
                    _characterFacade.ColliderWithAWall(typeObstacle);
                    break;
                case TypeObstacle.RightWall:
                    DoCameraShake();
                    _characterFacade.ColliderWithAWall(typeObstacle);
                    break;
                case TypeObstacle.SpikeLeft:
                    _characterFacade.Die();
                    break;
                case TypeObstacle.SpikeRight:
                    _characterFacade.Die();
                    break;
            }
        }

        private void DoCameraShake() =>
            Camera.main.DOShakePosition(0.1f, 0.1f, 1, 90);
    }
}