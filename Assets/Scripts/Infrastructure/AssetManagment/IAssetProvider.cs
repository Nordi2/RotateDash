using UnityEngine;

namespace Assets.Scripts.Infrastructure.AssetManagment
{
    public interface IAssetProvider
    {
        GameObject LoadGameObject(string path);
    }
}