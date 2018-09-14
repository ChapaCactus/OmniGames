using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.WeaponSmith
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class PuzzlePiece : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private SpriteRenderer m_icon = null;
        #endregion

        #region properties
        public string Type { get; private set; } = "";
        public bool IsSelect { get; private set; } = false;
        #endregion

        #region unity callbacks
        private void Awake()
        {
        }
        #endregion

        #region public methods
        public void OnSelect()
        {
            IsSelect = !IsSelect;
        }
        #endregion
    }
}