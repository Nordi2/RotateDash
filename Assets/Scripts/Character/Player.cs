using UnityEngine;

namespace Assets.Scripts.Character
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _velocityX;
        [SerializeField] private float _velocityY;

        private int _reverseDirection = 1;

        private void Update()
        {
            if (!GameManager.Instance._isGameRunning)
            {
                _rigidbody.velocity = Vector2.zero;
                _rigidbody.gravityScale = 0;
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                _rigidbody.velocity = new Vector2(_velocityX * _reverseDirection, _velocityY);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("WallLeft"))
            {
                _reverseDirection = 1;
                ScoreManager.Instance.Score += 1;
                ScoreManager.Instance.UpdateScoreText();
                WallManager.Instance.EnableRightSpikes(4);
            }
            else if (collision.gameObject.CompareTag("WallRight"))
            {
                _reverseDirection = -1;
                ScoreManager.Instance.Score += 1;
                ScoreManager.Instance.UpdateScoreText();
                WallManager.Instance.EnableLeftSpikes(4);
            }
            else if (collision.gameObject.CompareTag("Spike"))
            {
                GameManager.Instance._isGameRunning = false;
                ScoreManager.Instance.ActivateRestartButton();
            }
        }


    }
}