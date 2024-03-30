using UnityEngine;

namespace Modules.Profile.View
{
	public class ProfileView : MonoBehaviour
	{
		[SerializeField] private PlayerInfoPanel m_playerInfoPanelView;

		public void UpdatePlayerPanel(string playerName,Sprite icon, string level, string experience, float experiencePercent)
		{
			m_playerInfoPanelView.SetName(playerName);
			m_playerInfoPanelView.SetIcon(icon);
			m_playerInfoPanelView.SetLevel(level);
			m_playerInfoPanelView.SetExperience(experience);
			m_playerInfoPanelView.FillProgressBar(experiencePercent);
		}
	}
}