using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class GlobalUI : MonoBehaviour
    {
        #region public methods
        public static GlobalUI Create()
        {
            var prefab = Resources.Load("") as GlobalUI;
            var entity = Instantiate(prefab, null);
            return entity;
        }
        #endregion
    }
}