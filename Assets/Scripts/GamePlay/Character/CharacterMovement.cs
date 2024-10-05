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
        private readonly DetectedWallObserver _detectedWallObserver;

        private short _reverseDirection = 1;

        public CharacterMovement(CharacterView characterView, CharacterConfig characterConfig, DetectedWallObserver detectedWallObserver)
        {
            _characterView = characterView;
            _characterConfig = characterConfig;
            _detectedWallObserver = detectedWallObserver;
        }

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
                _characterView.Rigidbody.velocity = new Vector2(_characterConfig.VelocityX * _reverseDirection, _characterConfig.VelocityY);
        }

        public void Dispose() =>
            _detectedWallObserver.TriggerEnter -= OnTriggerEnter;

        public void Initialize() =>
            _detectedWallObserver.TriggerEnter += OnTriggerEnter;

        private void OnTriggerEnter(Collision2D wall)
        {
            if (wall.gameObject.GetComponent<Wall>() is null)
                return;

            TypeWall newWall = wall.gameObject.GetComponent<Wall>().WallType;

            switch (newWall)
            {
                case TypeWall.LeftWall:
                    _reverseDirection = 1;
                    break;
                case TypeWall.RightWall:
                    _reverseDirection = -1;
                    break;
                default:
                    throw new ArgumentException(nameof(newWall));
            }
        }
    }
}