using Modules.Profile.Controller;
using Modules.Profile.Model;
using Modules.Profile.View;
using UnityEngine;
using Zenject;

namespace Modules.Profile
{
    public class ProfileModule : MonoInstaller
    {
        [SerializeField]
        private ProfileView m_profileView;
    
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ProfileController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ProfileModel>().AsSingle().NonLazy();
            Container.BindInstance(m_profileView).AsSingle().NonLazy();
        }
    }
}
