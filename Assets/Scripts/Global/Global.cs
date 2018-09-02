using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using UnityEngine.SceneManagement;

namespace CCG
{
    public static class Global
    {
        #region properties
        // ゲーム初期化済みか
        public static bool IsInitialized { get; private set; } = false;
        #endregion

        #region public methods
        public static void Init()
        {
            SceneManager.LoadScene("GlobalUI", LoadSceneMode.Additive);

            IsInitialized = true;
        }

        public static void LoadSceneAddtive(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        #endregion
    }
}