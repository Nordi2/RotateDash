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
                case TypeObstacle.LeftWall:
                    _characterFacade.ColliderWithAWall(typeObstacle);
                    break;
                case TypeObstacle.RightWall:
                    _characterFacade.ColliderWithAWall(typeObstacle);
                    break;
                case TypeObstacle.Spike:
                    _characterFacade.Die();
                    break;
            }
        }
    }
}