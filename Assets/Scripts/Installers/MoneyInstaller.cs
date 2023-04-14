using Services.Money;
using Zenject;

namespace Installers
{
    public class MoneyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Coin();
        }

        private void Coin()
        {
            Container.Bind<IBank>().To<CoinsBank>().AsSingle().NonLazy();
        }
    }
}