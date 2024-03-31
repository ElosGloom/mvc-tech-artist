using System;
using System.Collections.Generic;
using Data;
using Data.Matching;
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
        private readonly MatchButtonView.Factory m_matchButtonFactory;
        private readonly MatchParameterCellView.Factory m_matchParameterCellFactory;

        private readonly ClearableContainer m_activeMatchParameters = new ClearableContainer();

        public ProfileController(
            ProfileModel model,
            ProfileView view,
            AchievementsGroupView.Factory achievementGroupFactory,
            AchievementCellView.Factory achievementCellFactory,
            MatchButtonView.Factory matchButtonFactory,
            MatchParameterCellView.Factory matchParameterCellFactory)
        {
            m_model = model;
            m_view = view;
            m_achievementGroupFactory = achievementGroupFactory;
            m_achievementCellFactory = achievementCellFactory;
            m_matchButtonFactory = matchButtonFactory;
            m_matchParameterCellFactory = matchParameterCellFactory;
        }

        public void Initialize()
        {
            var accountData = m_model.GetAccount();
            InitPlayerPanel(accountData);
            InitAchievementPanel(accountData);
            InitMatchStatsPanel(accountData);
        }

        public void Dispose()
        {
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

                    var protocol = new AchievementCellProtocol
                    {
                        AchievementName = achievement.Name.ToUpper(),
                        Date = $"COMPLETED ON: {achievement.CompletedOn:dd'/'MM'/'yyyy}",
                        Icon = Resources.Load<Sprite>(achievement.Icon)
                    };

                    var achievementCell = m_achievementCellFactory.Create(protocol);
                    groupView.AddCell(achievementCell);
                }

                m_view.AddAchievementGroup(groupView);
            }
        }

        private void InitMatchStatsPanel(AccountData accountData)
        {
            if (accountData.Matches.Length == 0)
            {
                return;
            }

            const int maxMatchButtonCount = 3;
            var lastMatches = accountData.Matches.GetLastElements(maxMatchButtonCount);

            foreach (var match in lastMatches)
            {
                var protocol = new MatchButtonProtocol
                {
                    MatchType = match.MatchType.ToString().ToUpper(),
                    Icon = Resources.Load<Sprite>(match.Icon)
                };

                var matchButton = m_matchButtonFactory.Create(protocol);
                m_view.AddMatchButtonCell(matchButton);
                matchButton.ButtonClickEvent.AddListener(() => SetMatchParameters(match.Parameters));
            }
            
            SetMatchParameters(accountData.Matches[0].Parameters);
        }


        private void SetMatchParameters(MatchParameter[] matchParameters)
        {
            m_activeMatchParameters.Clear();
            foreach (var parameter in matchParameters)
            {
                var protocol = new MatchParametersProtocol
                {
                    Header = parameter.Header.ToUpper(),
                    SubHeader = parameter.SubHeader.ToUpper(),
                    Score = $"{parameter.Score} 000 PT."
                };
                var createdCell = m_matchParameterCellFactory.Create(protocol);
                m_activeMatchParameters.Add(createdCell);
                m_view.AddMatchParameters(createdCell);
            }
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