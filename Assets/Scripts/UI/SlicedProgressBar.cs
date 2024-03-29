using UnityEngine;

namespace UI
{
    public class SlicedProgressBar : MonoBehaviour
    {
        [SerializeField] private RectTransform filler;
        [SerializeField] private float inset = 3;

        private float _parentWidth;


        private void Start()
        {
            if (transform.parent is RectTransform parent)
                _parentWidth = parent.sizeDelta.x;
        }
        
        public void Fill(float percent)
        {
            var distance = _parentWidth * percent - inset * 2;
            filler.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, inset, distance);
        }
    }
}