using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Profile.View
{
    public class ProfileWindowButtonView : MonoBehaviour
    {
        [SerializeField] private Button m_button;
        [SerializeField] private TextMeshProUGUI m_text;

        [SerializeField] private Color m_enabledColor;
        [SerializeField] private Color m_disabledColor;

        [SerializeField] private Material m_defaultFontMaterial;
        [SerializeField] private Material m_glowFontMaterial;
        

        public void SetButtonActive(bool isActive)
        {
            m_button.interactable = isActive;
            if (isActive)
            {
                m_text.color = m_enabledColor;
                m_text.fontSharedMaterial = m_defaultFontMaterial;
            }
            else
            {
                m_text.color = m_disabledColor;
                m_text.fontSharedMaterial = m_glowFontMaterial;
            }
        }
    }
}