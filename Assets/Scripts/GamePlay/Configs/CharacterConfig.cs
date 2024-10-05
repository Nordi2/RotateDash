using UnityEngine;

namespace Assets.Scripts.GamePlay.Configs
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "ScritableObjects/Character")]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public float VelocityX { get; private set; }
        [field: SerializeField] public float VelocityY { get; private set; }
    }
}