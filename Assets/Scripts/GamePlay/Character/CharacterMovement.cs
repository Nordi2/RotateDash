using Assets.Scripts.GamePlay.Configs;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.GamePlay.Character
{
    public class CharacterMovement : ITickable, IInitializable, IDisposable
    {
        private readonly CharacterView _characterView;
        private readonly CharacterConfig _characterConfig;
        private readonly ICharacterFacade _characterFacade;

        private short _reverseDirection = 1;

        public CharacterMovement(CharacterView characterView, CharacterConfig characterConfig, ICharacterFacade characterFacade)
        {
            _characterView = characterView;
            _characterConfig = characterConfig;
            _characterFacade = characterFacade;
        }

        public void Initialize() =>
            _characterFacade.OnColliderWithWall += SwitchDirection;

        public void Dispose() =>
            _characterFacade.OnColliderWithWall -= SwitchDirection;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
                _characterView.Rigidbody.velocity = new Vector2(_characterConfig.VelocityX * _reverseDirection, _characterConfig.VelocityY);
        }

        private void SwitchDirection(TypeObstacle obstacle)
        {
            switch (obstacle)
            {
                case TypeObstacle.LeftWall:
                    _reverseDirection = 1;
                    break;
                case TypeObstacle.RightWall:
                    _reverseDirection = -1;
                    break;
            }
        }
    }
}