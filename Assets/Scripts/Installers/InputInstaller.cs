using Services.Input;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Input();
        }

        private void Input()
        {
            if (Application.isEditor)
            {
                Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle().NonLazy();
            }
            else
            {
                Container.Bind<IInputService>().To<MobileInputService>().AsSingle().NonLazy();
            }
        }
    }
}