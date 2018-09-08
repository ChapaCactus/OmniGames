using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class SceneBase : MonoBehaviour
    {
        #region unity callbacks
        private void Awake()
        {
            Global.CurrentGameScene = this;
            OnAwake();
        }

        private void Start()
        {
            OnStart();
        }

        private void Update()
        {
            OnUpdate();
        }
        #endregion

        #region private methods
        protected virtual void OnAwake()
        {
        }

        protected virtual void OnStart()
        {
        }

        protected virtual void OnUpdate()
        {
        }
        #endregion
    }
}