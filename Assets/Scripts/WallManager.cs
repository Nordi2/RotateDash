using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WallManager : MonoBehaviour
    {
        public static WallManager Instance;

        [SerializeField] private List<GameObject> _leftSpikes;
        [SerializeField] private List<GameObject> _rightSpikes;

        private void Awake()
        {
            Instance = this;
            EnableRightSpikes(4);
        }

        public void EnableLeftSpikes(int numberOfSpikes)
        {
            DisableRightSpikes();
            for (int i = 0; i < numberOfSpikes; i++)
            {
                int random = Random.Range(0, _leftSpikes.Count);
                _leftSpikes[random].SetActive(true);
            }
        }

        public void EnableRightSpikes(int numberOfSpikes)
        {
            DisableLeftSpikes();
            for (int i = 0; i < numberOfSpikes; i++)
            {
                int random = Random.Range(0, _rightSpikes.Count);
                _rightSpikes[random].SetActive(true);
            }
        }

        private void DisableRightSpikes()
        {
            for (int i = 0; i < _rightSpikes.Count; i++)
            {
                _rightSpikes[i].SetActive(false);
            }
        }

        private void DisableLeftSpikes()
        {
            for (int i = 0; i < _leftSpikes.Count; i++)
            {
                _leftSpikes[i].SetActive(false);
            }
        }
    }
}