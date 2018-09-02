using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class SnowballPitcher : MonoBehaviour
    {
        #region properties
        public Enum.DirectionY DirectionY { get; private set; }
        #endregion

        #region public methods
        public void Setup(Enum.DirectionY directionY)
        {
            DirectionY = directionY;
        }
        #endregion

        #region private methods
        /// <summary>
        /// 雪玉を投げる
        /// </summary>
        private void Throw(Snowball snowball)
        {
            snowball.Setup(DirectionY);
        }
        #endregion
    }
}