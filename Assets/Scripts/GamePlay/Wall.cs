using UnityEngine;

namespace Assets.Scripts.GamePlay
{
    public class Wall : MonoBehaviour
    {
        [SerializeField] private TypeWall _wallType;

        public TypeWall WallType => _wallType;
    }
}