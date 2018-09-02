using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CCG
{
    public class GlobalUI : SingletonMonoBehaviour<GlobalUI>
    {
        #region variables
        [SerializeField]
        private Button m_backToTitleButton = null;
        #endregion

        #region unity callbacks
        private void Awake()
        {
            Init();
        }
        #endregion

        #region public methods
        public void Init()
        {
            SetActive(false);
            m_backToTitleButton.onClick.AddListener(OnClickBackToTitle);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        #endregion

        #region private methods
        private void OnClickBackToTitle()
        {
        }
        #endregion
    }
}