using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public static class Global
    {
        #region properties
        public static GlobalUI GlobalUI { get; private set; }
        // ゲーム初期化済みか
        public static bool IsInitialized { get; private set; } = false;
        #endregion

        #region public methods
        public static void Init()
        {
            GlobalUI = GlobalUI.Create();
            GlobalUI.Init();

            IsInitialized = true;
        }
        #endregion
    }
}