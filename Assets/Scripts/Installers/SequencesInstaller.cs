using Services.Sequence;
using Zenject;

namespace Installers
{
    public class SequencesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameplaySequence();
        }

        private void GameplaySequence()
        {
            Container.Bind<IGameplaySequence>().To<GameplaySequence>().AsSingle().NonLazy();
        }
    }
}