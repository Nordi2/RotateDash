using UnityEngine;

namespace Assets.Scripts.GamePlay
{
    public class ObstacleObject : MonoBehaviour
    {
        [SerializeField] private TypeObstacle _typeObstacle;

        public TypeObstacle TypeObstacle => _typeObstacle;
    }
}