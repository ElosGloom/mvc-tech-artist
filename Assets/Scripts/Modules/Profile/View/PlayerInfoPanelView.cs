using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoPanelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_playerName;
    [SerializeField] private Image m_playerIcon;
    [SerializeField] private TextMeshProUGUI m_level;
    [SerializeField] private TextMeshProUGUI m_experience;
    [SerializeField] private SlicedProgressBar m_progressBar;


    public void SetName(string playerName)
    {
        m_playerName.text = playerName;
    }

    public void SetIcon(Sprite icon)
    {
        m_playerIcon.sprite = icon;
    }

    public void SetLevel(string level)
    {
        m_level.text = level;
    }

    public void SetExperience(string experience)
    {
        m_experience.text = experience;
    }

    public void FillProgressBar(float percent)
    {
        m_progressBar.Fill(percent);
    }
}