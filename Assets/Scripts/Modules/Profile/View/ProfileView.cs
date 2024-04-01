using UnityEngine;
using UnityEngine.UI;

namespace Modules.Profile.View
{
    public class ProfileView : MonoBehaviour
    {
        [SerializeField] private PlayerInfoPanelView m_playerInfoPanelView;
        [SerializeField] private ProfileWindowsPanelView m_profileWindowPanel;
        [SerializeField] private Transform m_achievementsParent;
        [SerializeField] private Transform m_matchButtonParent;
        [SerializeField] private Transform m_matchContentParent;
        [SerializeField] private Button m_achiementButton;
        [SerializeField] private Button m_overviewButton;


        public Button.ButtonClickedEvent AchievementButtonClickedEvent => m_achiementButton.onClick;
        public Button.ButtonClickedEvent OverviewButtonClickedEvent => m_overviewButton.onClick;

        public void UpdatePlayerPanel(string playerName, Sprite icon, string level, string experience,
            float experiencePercent)
        {
            m_playerInfoPanelView.SetName(playerName);
            m_playerInfoPanelView.SetIcon(icon);
            m_playerInfoPanelView.SetLevel(level);
            m_playerInfoPanelView.SetExperience(experience);
            m_playerInfoPanelView.FillProgressBar(experiencePercent);
        }

        public void ActivateInternalWindow(ProfileWindowsPanelView.WindowType windowType)
        {
            m_profileWindowPanel.ActivateWindow(windowType);
        }

        public void AddAchievementGroup(AchievementsGroupView achievementsGroup)
        {
            achievementsGroup.transform.SetParent(m_achievementsParent, false);
        }

        public void AddMatchButtonCell(MatchButtonView matchButton)
        {
            matchButton.transform.SetParent(m_matchButtonParent, false);
        }

        public void AddMatchParameters(MatchParameterCellView matchParameterCell)
        {
            matchParameterCell.transform.SetParent(m_matchContentParent, false);
        }
    }
}