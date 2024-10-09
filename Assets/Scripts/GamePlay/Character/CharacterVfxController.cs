using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.GamePlay.Character
{
    public class CharacterVfxController : IInitializable, IDisposable
    {
        private const int ANGLE_ROTATION_VFX = 90;

        private readonly CharacterView _characterView;
        private readonly ICharacterFacade _characterFacade;

        public CharacterVfxController(CharacterView characterView, ICharacterFacade characterFacade)
        {
            _characterView = characterView;
            _characterFacade = characterFacade;
        }

        public void Initialize()
        {
            _characterFacade.OnColliderWithWall += ActivateVfxConflict;
        }

        public void Dispose()
        {
            _characterFacade.OnColliderWithWall -= ActivateVfxConflict;
        }

        private void ActivateVfxConflict(TypeObstacle obstacle)
        {
            switch (obstacle)
            {
                case TypeObstacle.LeftWall:
                    PlayParticleSystem(new Vector3(0, ANGLE_ROTATION_VFX, 0));
                    break;
                case TypeObstacle.RightWall:
                    PlayParticleSystem(new Vector3(0, -ANGLE_ROTATION_VFX, 0));
                    break;
            }
        }

        private void PlayParticleSystem(Vector3 rot)
        {
            var shape = _characterView.ParticlePrefab.shape;
            shape.rotation = rot;
            _characterView.ParticlePrefab.Play();
        }
    }
}