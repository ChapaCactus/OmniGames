using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public static class Global
    {
        #region properties
        public static bool IsInitialized { get; private set; } = false;
        #endregion

        #region public methods
        public static void Init()
        {
            IsInitialized = true;
        }
        #endregion
    }
}