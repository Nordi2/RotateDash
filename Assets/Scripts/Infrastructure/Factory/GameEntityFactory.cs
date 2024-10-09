using Assets.Scripts.Infrastructure.AssetManagment;
using Zenject;

namespace Assets.Scripts.Infrastructure.Factory
{
    public class GameEntityFactory : IGameEntityFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        public GameEntityFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        //public TImplementation InstantiatePrefab<TImplementation>()
        //{
        //}
    }
}