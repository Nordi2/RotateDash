using System;

namespace Assets.Scripts.GamePlay.Character
{
    public interface ICharacterFacade
    {
        public event Action OnDie;
        public event Action<TypeObstacle> OnColliderWithWall;

        public void Die();
        public void ColliderWithAWall(TypeObstacle typeObstacle = TypeObstacle.None);
    }
}