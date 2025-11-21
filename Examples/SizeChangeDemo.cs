using System;
using TMPro;
using UnityEngine;

namespace Poke.UI
{
    public class SizeChangeDemo : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_text;
        [SerializeField] private TMP_Text m_text2;
        [SerializeField] private float m_minSize = 12;
        [SerializeField] private float m_maxSize = 48;
        
        private void Update() {
            float t = Mathf.Sin(Time.unscaledTime) * 0.5f + 0.5f;
            float t2 = Mathf.Cos(Time.unscaledTime) * 0.5f + 0.5f;
            m_text.fontSize = Mathf.Lerp(m_minSize, m_maxSize, t);
            m_text2.fontSize = Mathf.Lerp(m_minSize, m_maxSize, t2);
        }
    }
}
