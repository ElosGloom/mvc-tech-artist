using UnityEngine;

namespace UI
{
    public class SlicedProgressBar : MonoBehaviour
    {
        [SerializeField] private RectTransform m_filler;
        [SerializeField] private float m_inset = 3;


        public void Fill(float percent)
        {
            if (transform is RectTransform rectTransform)
            {
                var distance = rectTransform.rect.width * percent - m_inset * 2;
                m_filler.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, m_inset, distance);
            }
        }
    }
}