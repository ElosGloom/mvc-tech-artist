using System;
using Data;
using Modules.Profile.Model;
using Modules.Profile.View;
using UnityEngine;
using Zenject;

namespace Modules.Profile.Controller
{
    public class ProfileController : IInitializable, IDisposable
    {
        private readonly ProfileModel m_model;
        private readonly ProfileView m_view;

        public ProfileController(ProfileModel model, ProfileView view)
        {
            m_model = model;
            m_view = view;
        }

        public void Initialize()
        {
            var accountData = m_model.GetAccount();
            InitPlayerPanel(accountData);
        }

        public void Dispose()
        {
        }

        private void InitPlayerPanel(AccountData accountData)
        {
            var icon = Resources.Load<Sprite>(accountData.AvatarIcon);
            var expPercent = (float)accountData.Experience / accountData.ExperienceMax;
            var level = $"LEVEL: {accountData.Level}";
            var experience = $"{accountData.Experience}/{accountData.ExperienceMax}";
            m_view.UpdatePlayerPanel(accountData.Name, icon, level, experience, expPercent);
        }
    }
}