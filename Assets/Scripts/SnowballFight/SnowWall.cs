using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class SnowWall : MonoBehaviour
    {
        #region properties
        public Enum.Side Side { get; private set; }
        #endregion
        
        #region public methods
        public void Setup(Enum.Side side)
        {
            Side = side;

            // サイドによって向きを変えておく
            var zRotate = (side == Enum.Side.Player1) ? 0 : 180;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotate));
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void Break()
        {
            SetActive(false);
        }
        #endregion
    }
}