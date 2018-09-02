using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.UI;

namespace CCG
{
    public class GlobalUI : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private Button m_backToTitleButton = null;
        #endregion

        #region unity callbacks
        private void Awake()
        {
            m_backToTitleButton.onClick.AddListener(OnClickBackToTitle);
        }
        #endregion

        #region public methods
        public static GlobalUI Create()
        {
            var prefab = Resources.Load("") as GlobalUI;
            var entity = Instantiate(prefab, null);
            return entity;
        }

        public void Init()
        {
            SetActive(false);
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