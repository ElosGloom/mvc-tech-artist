using UnityEngine;

namespace Modules.Profile.View
{
    public class ProfileWindowsPanelView : MonoBehaviour
    {
        [SerializeField] private ProfileWindowButtonView m_achievementsButton;
        [SerializeField] private GameObject m_achievementWindow;

        [SerializeField] private ProfileWindowButtonView m_overviewButtton;
        [SerializeField] private GameObject m_overviewWindow;
        

        public void ActivateWindow(WindowType windowType)
        {
            switch (windowType)
            {
                case WindowType.Achievements:
                    m_achievementsButton.SetButtonActive(false);
                    m_overviewButtton.SetButtonActive(true);

                    m_achievementWindow.SetActive(true);
                    m_overviewWindow.SetActive(false);
                    break;

                case WindowType.Overview:
                    m_achievementsButton.SetButtonActive(true);
                    m_overviewButtton.SetButtonActive(false);

                    m_achievementWindow.SetActive(false);
                    m_overviewWindow.SetActive(true);
                    break;
            }
        }

        public enum WindowType
        {
            Achievements,
            Overview
        }
    }
}