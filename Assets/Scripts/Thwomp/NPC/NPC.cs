using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.Thwomp
{
    public class NPC : MonoBehaviour
    {
        #region properties
        private bool CanMove { get; set; } = false;
        private bool IsRight = false;
        private float MoveSpeed { get { return Time.deltaTime * 0.9f; } }
        #endregion

        #region unity callbacks
        private void Update()
        {
            transform.Translate(new Vector3(IsRight? MoveSpeed : -MoveSpeed, 0, 0));
        }
        #endregion

        #region public methods
        public void OnSpawn()
        {
            CanMove = true;
        }
        #endregion
    }
}