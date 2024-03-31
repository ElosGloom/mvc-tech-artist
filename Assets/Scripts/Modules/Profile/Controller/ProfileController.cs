using System;
using Data;
using Modules.Profile.Model;
using Modules.Profile.View;
using UI;
using UnityEngine;
using Zenject;

namespace Modules.Profile.Controller
{
    public class ProfileController : IInitializable, IDisposable
    {
        private readonly ProfileModel m_model;
        private readonly ProfileView m_view;
        private readonly AchievementsGroupView.Factory m_achievementGroupFactory;
        private readonly AchievementCellView.Factory m_achievementCellFactory;

        public ProfileController(
            ProfileModel model,
            ProfileView view,
            AchievementsGroupView.Factory achievementGroupFactory,
            AchievementCellView.Factory achievementCellFactory)
        {
            m_model = model;
            m_view = view;
            m_achievementGroupFactory = achievementGroupFactory;
            m_achievementCellFactory = achievementCellFactory;
        }

        public void Initialize()
        {
            var accountData = m_model.GetAccount();
            InitPlayerPanel(accountData);
            InitAchievementPanel(accountData);
        }

        private void InitAchievementPanel(AccountData accountData)
        {
            int groupsCount = (int)Math.Ceiling((double)accountData.Achievements.Length / 3);

            for (int i = 0; i < groupsCount; i++)
            {
                var groupView = m_achievementGroupFactory.Create();

                for (int j = i * 3; j < Math.Min((i + 1) * 3, accountData.Achievements.Length); j++)
                {
                    var achievement = accountData.Achievements[j];

                    var protocol = new AchievementCellProtocol();
                    protocol.AchievementName = achievement.Name.ToUpper();
                    protocol.Date = $"COMPLETED ON: {achievement.CompletedOn:dd'/'MM'/'yyyy}";
                    protocol.Icon = Resources.Load<Sprite>(achievement.Icon);

                    var achievementCell = m_achievementCellFactory.Create(protocol);
                    groupView.AddCell(achievementCell);
                }

                m_view.AddAchievementGroup(groupView);
            }
        }

        public void Dispose()
        {
        }

        private void InitPlayerPanel(AccountData accountData)
        {
            var name = $"#{accountData.Name.ToUpper()}";
            var icon = Resources.Load<Sprite>(accountData.AvatarIcon);
            var expPercent = (float)accountData.Experience / accountData.ExperienceMax;
            var level = $"LEVEL: {accountData.Level}";
            var experience = $"{accountData.Experience}/{accountData.ExperienceMax}";
            m_view.UpdatePlayerPanel(name, icon, level, experience, expPercent);
        }
    }
}