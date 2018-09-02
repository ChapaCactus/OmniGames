using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.SceneManagement;

namespace CCG
{
    public class Title : MonoBehaviour
    {
        #region unity callbacks
        private void Awake()
        {
            Global.Init();
        }
        #endregion
    }
}