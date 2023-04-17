using UI.Screens.GamePlay;
using Zenject;

namespace Installers
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GamePlay();
        }

        private void GamePlay()
        {
            Container.Bind<GamePlayModel>().AsSingle().NonLazy();
        }
    }
}