using System.Collections.Generic;
using Entities.Drops;
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
        
        [SerializeField] private MonoObjectPool _monoObjectPoolHealth;
        [SerializeField] private MonoObjectPool _monoObjectPoolShield;
        [SerializeField] private MonoObjectPool _monoObjectPoolMagnet;
        [SerializeField] private MonoObjectPool _monoObjectPoolNitro;
        
        [SerializeField] private MonoObjectPool _monoObjectPoolCoin;

        private Services.Factories.IFactoryProvider<Drop> _factoryDropProvider;

        public override void InstallBindings()
        {
            _factoryDropProvider = new Services.Factories.FactoryProvider<Drop>(
                new KeyValuePair<string, IFactory<Drop>>[]
                {
                    new("Police", new PoolFactory<Drop>(_monoObjectPoolPolice.GetObjectPool(Container))),
                    new("Block", new PoolFactory<Drop>(_monoObjectPoolBlock.GetObjectPool(Container))),
                    new("Oil", new PoolFactory<Drop>(_monoObjectPoolOil.GetObjectPool(Container))),
                    new("Crack", new PoolFactory<Drop>(_monoObjectPoolCrack.GetObjectPool(Container))),
                    
                    new("Health", new PoolFactory<Drop>(_monoObjectPoolHealth.GetObjectPool(Container))),
                    new("Shield", new PoolFactory<Drop>(_monoObjectPoolShield.GetObjectPool(Container))),
                    new("Magnet", new PoolFactory<Drop>(_monoObjectPoolMagnet.GetObjectPool(Container))),
                    new("Nitro", new PoolFactory<Drop>(_monoObjectPoolNitro.GetObjectPool(Container))),
                    
                    new("Coin", new PoolFactory<Drop>(_monoObjectPoolCoin.GetObjectPool(Container))),
                });

            Container.Bind<Services.Factories.IFactoryProvider<Drop>>().FromInstance(_factoryDropProvider).AsSingle();
        }
    }
}