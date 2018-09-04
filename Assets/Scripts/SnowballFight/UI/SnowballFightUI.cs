using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;
using DG.Tweening;

namespace CCG
{
    public class SnowballFightUI : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private Text m_popText = null;
        #endregion

        #region properties
        private Sequence PopTextSequence { get; set; }
        #endregion

        #region public methods
        public void PlayPopText(string text)
        {
            if(PopTextSequence != null)
            {
                PopTextSequence.Kill();
                PopTextSequence = null;
            }

            m_popText.text = text;
            PopTextSequence = DOTween.Sequence();
            PopTextSequence.Append(m_popText.DOFade(1, 0.2f))
                           .Append(m_popText.DOFade(1, 1.0f))
                           .Append(m_popText.DOFade(0, 0.2f))
                           .OnComplete(() =>
                           {
                               PopTextSequence = null;
                           });
        }

        [ContextMenu("Debug")]
        public void Debug()
        {
            PlayPopText("Test");
        }
        #endregion
    }
}