using System;
using UnityEngine;

namespace Assets.Scripts.GamePlay.Character
{
    public class CharacterFacade : MonoBehaviour, ICharacterFacade
    {
        public event Action OnDie;
        public event Action<TypeObstacle> OnColliderWithWall;

        public void ColliderWithAWall(TypeObstacle typeObstacle) =>
            OnColliderWithWall?.Invoke(typeObstacle);

        public void Die() =>
            OnDie?.Invoke();
    }
}