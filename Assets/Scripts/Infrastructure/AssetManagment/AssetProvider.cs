using UnityEngine;

namespace Assets.Scripts.Infrastructure.AssetManagment
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject LoadGameObject(string path)
        {
            GameObject gameObject = Resources.Load<GameObject>(path);
            return gameObject;
        }
    }
}