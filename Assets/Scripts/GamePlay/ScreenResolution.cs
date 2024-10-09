using UnityEngine;
using Zenject;

namespace Assets.Scripts.GamePlay
{
    public class ScreenResolution : IInitializable
    {
        private Camera _camera;

        public float ScreenWidth { get; private set; }
        public float ScreenHeight { get; private set; }
        public Vector3 ScreenToWorldPoint { get; private set; }

        public void Initialize()
        {
            _camera = Camera.main;
            ScreenWidth = Screen.width;
            ScreenHeight = Screen.height;

            ScreenToWorldPoint = _camera.ScreenToWorldPoint(new Vector3(ScreenWidth, ScreenHeight, _camera.nearClipPlane));
        }
    }
}