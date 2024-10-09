using UnityEngine;

namespace Assets.Scripts.GamePlay.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "ScritableObjects/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField, Min(1)] public int InitialCountSpikes { get; private set; }
        [field: SerializeField, Min(1)] public int MaxCountSpikesInLevel { get; private set; }
        [field: SerializeField, Min(1)] public float TimeBeforeAddCountActiveSpikes { get; private set; }

        private void OnValidate()
        {
            if (InitialCountSpikes >= MaxCountSpikesInLevel)
            {
                MaxCountSpikesInLevel = InitialCountSpikes + 1;
            }
        }
    }
}