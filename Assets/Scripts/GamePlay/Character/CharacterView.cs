using UnityEngine;

namespace Assets.Scripts.GamePlay.Character
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private ParticleSystem _particlePrefabConflict;

        public Rigidbody2D Rigidbody => _rigidbody;
        public ParticleSystem ParticlePrefab => _particlePrefabConflict;
    }
}