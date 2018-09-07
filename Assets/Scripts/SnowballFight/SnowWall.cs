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
        public int Health { get; private set; }
        #endregion
        
        #region public methods
        public void Setup(Enum.Side side)
        {
            Side = side;
            Health = 3;

            // サイドによって向きを変えておく
            var zRotate = (side == Enum.Side.Player1) ? 0 : 180;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotate));

            Reset();
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void Break()
        {
            transform.localScale *= 0.75f;

            Health--;
            if(Health <= 0)
            {
                SetActive(false);
            }
        }

        public void Reset()
        {
            transform.localScale = Vector2.one;
        }
        #endregion
    }
}