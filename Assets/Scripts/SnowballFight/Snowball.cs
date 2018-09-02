using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class Snowball : MonoBehaviour
    {
        #region properties
        public Enum.DirectionY DirectionY { get; private set; }
        public float Speed { get; private set; }
        #endregion

        #region public methods
        public void Setup(Enum.DirectionY dirY, float speed = 1)
        {
            DirectionY = dirY;
            Speed = speed;
        }
        #endregion
    }
}