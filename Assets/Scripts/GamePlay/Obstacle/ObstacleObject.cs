using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.GamePlay
{
    public class ObstacleObject : MonoBehaviour
    {
        [SerializeField] private TypeObstacle _typeObstacle;
        [SerializeField] private Vector2 _offset;

        private ScreenResolution _screenResolution;

        [Inject]
        private void Construct(ScreenResolution screenResolution)
        {
            _screenResolution = screenResolution;
        }

        public TypeObstacle TypeObstacle => _typeObstacle;

        private void Start()
        {
            switch (_typeObstacle)
            {
                case TypeObstacle.None:
                    throw new ArgumentException("The type of obstacle is not selected");
                case TypeObstacle.LeftWall:
                    transform.position = GetPosition(new Vector3(-_screenResolution.ScreenToWorldPoint.x, 0, 0), default, -_offset);
                    break;
                case TypeObstacle.RightWall:
                    transform.position = GetPosition(new Vector3(_screenResolution.ScreenToWorldPoint.x, 0, 0), default, _offset);
                    break;
                case TypeObstacle.UpWall:
                    transform.position = GetPosition(new Vector3(0, _screenResolution.ScreenToWorldPoint.y, 0), _offset, default);
                    break;
                case TypeObstacle.BottonWall:
                    transform.position = GetPosition(new Vector3(0, -_screenResolution.ScreenToWorldPoint.y, 0), -_offset, default);
                    break;
                case TypeObstacle.SpikeLeft:
                    transform.position = GetPosition(new Vector3(-_screenResolution.ScreenToWorldPoint.x, transform.position.y, 0), default, -_offset);
                    break;
                case TypeObstacle.SpikeRight:
                    transform.position = GetPosition(new Vector3(_screenResolution.ScreenToWorldPoint.x, transform.position.y, 0), default, _offset);
                    break;
            }
        }

        private Vector3 GetPosition(Vector3 vector, Vector2 offsetY, Vector2 offsetX) =>
            new Vector3(vector.x + offsetX.x, vector.y + offsetY.y, vector.z);
    }
}