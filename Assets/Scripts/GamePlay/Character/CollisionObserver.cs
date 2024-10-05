using System;
using UnityEngine;

namespace Assets.Scripts.GamePlay.Character
{
    public class CollisionObserver<TImplementation> : MonoBehaviour
    {
        public event Action<Collision2D> TriggerEnter;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponentInParent<TImplementation>() is not null)
                TriggerEnter?.Invoke(collision);
        }

    }
}