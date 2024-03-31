using UI;
using UnityEngine;

namespace Modules.Profile.View
{
    public class ProfileView : MonoBehaviour
    {
        [SerializeField] private PlayerInfoPanelView m_playerInfoPanelView;
        [SerializeField] private Transform m_achievementsParent;
        [SerializeField] private Transform m_matchButtonParent;
        [SerializeField] private Transform m_matchContentParent;
        
        


        public void UpdatePlayerPanel(string playerName, Sprite icon, string level, string experience,
            float experiencePercent)
        {
            m_playerInfoPanelView.SetName(playerName);
            m_playerInfoPanelView.SetIcon(icon);
            m_playerInfoPanelView.SetLevel(level);
            m_playerInfoPanelView.SetExperience(experience);
            m_playerInfoPanelView.FillProgressBar(experiencePercent);
        }
        
        public void AddAchievementGroup(AchievementsGroupView achievementsGroup)
        {
            achievementsGroup.transform.SetParent(m_achievementsParent);
        }

        public void AddMatchButtonCell(MatchButtonView matchButton)
        {
           matchButton.transform.SetParent(m_matchButtonParent); 
        }

        public void AddMatchParameters(MatchParameterCellView matchParameterCell)
        {
            matchParameterCell.transform.SetParent(m_matchContentParent);
        }
        
    }
}