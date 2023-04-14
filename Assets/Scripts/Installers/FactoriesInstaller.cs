using System.Collections.Generic;
using Entities.Enemies;
using Services.Pools;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        [SerializeField] private MonoObjectPool _monoObjectPoolPolice;
        [SerializeField] private MonoObjectPool _monoObjectPoolBlock;
        [SerializeField] private MonoObjectPool _monoObjectPoolOil;
        [SerializeField] private MonoObjectPool _monoObjectPoolCrack;

        private Services.Factories.IFactoryProvider<Enemy> _factoryDropProvider;

        public override void InstallBindings()
        {
            _factoryDropProvider = new Services.Factories.FactoryProvider<Enemy>(
                new KeyValuePair<string, IFactory<Enemy>>[]
                {
                    new("Police", new PoolFactory<Enemy>(_monoObjectPoolPolice.GetObjectPool(Container))),
                    new("Block", new PoolFactory<Enemy>(_monoObjectPoolBlock.GetObjectPool(Container))),
                    new("Oil", new PoolFactory<Enemy>(_monoObjectPoolOil.GetObjectPool(Container))),
                    new("Crack", new PoolFactory<Enemy>(_monoObjectPoolCrack.GetObjectPool(Container))),
                });

            Container.Bind<Services.Factories.IFactoryProvider<Enemy>>().FromInstance(_factoryDropProvider).AsSingle();
        }
    }
}