using TMPro;
using UnityEngine;

namespace Poke.UI {
    [
        ExecuteAlways,
        RequireComponent(typeof(TMP_Text))
    ]
    public class LayoutText : MonoBehaviour
    {
        [SerializeField] private SizingMode m_sizingX = SizingMode.FitContent;
        [SerializeField] private SizingMode m_sizingY = SizingMode.FitContent;
        [SerializeField, Min(0)] private float m_maxWidth;
        
        private RectTransform _rect;
        private RectTransform _parent;
        private TMP_Text _text;
        private DrivenRectTransformTracker _rectTracker;

        private void Awake() {
            _rect = GetComponent<RectTransform>();
            _text = GetComponent<TMP_Text>();
            
            _rectTracker = new DrivenRectTransformTracker();
        }

        private void OnEnable() {
            _parent = transform.parent.GetComponent<RectTransform>();
        }

        public void Update() {
            _text.textWrappingMode = m_sizingX == SizingMode.Inherit ? TextWrappingModes.Normal : TextWrappingModes.NoWrap;
            
            _rectTracker.Clear();
            if(m_sizingX != SizingMode.None)
                _rectTracker.Add(this, _rect, DrivenTransformProperties.SizeDeltaX);
            if(m_sizingY != SizingMode.None)
                _rectTracker.Add(this, _rect, DrivenTransformProperties.SizeDeltaY);
            
            Vector2 size = _text.GetPreferredValues(_text.text);
            
            // X Pass
            if(m_sizingX == SizingMode.Inherit) {
                size.x = _parent.rect.size.x;
                if(m_maxWidth > 0) {
                    size.x = Mathf.Min(size.x, m_maxWidth);
                }
            }
            if(m_sizingX != SizingMode.None) {
                _rect.sizeDelta = _rect.sizeDelta.With(x: size.x);
            }
            
            // Y Pass
            if(m_sizingY == SizingMode.Inherit) {
                size.y = _parent.rect.size.y;
            }

            if(m_sizingY == SizingMode.FitContent) {
                float height = 0;
                for(int i = 0; i < _text.textInfo.lineCount; i++) {
                    float lineHeight = _text.textInfo.lineInfo[i].lineHeight;
                    height += lineHeight;
                }
                size.y = height;
            }
            if(m_sizingY != SizingMode.None) {
                _rect.sizeDelta = _rect.sizeDelta.With(y: size.y);
            }
        }
    }
    
}
