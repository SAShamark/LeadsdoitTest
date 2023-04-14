using Entities.Point;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PointsInstaller : MonoInstaller
    {
        [SerializeField] private Points _points;

        public override void InstallBindings()
        {
            Points();
        }

        private void Points()
        {
            Container.Bind<IPointsProvider>().FromInstance(_points).AsSingle().NonLazy();
        }
    }
}