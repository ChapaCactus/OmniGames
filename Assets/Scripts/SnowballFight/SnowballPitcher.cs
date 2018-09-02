using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.SnowballFight
{
    public class SnowballPitcher : MonoBehaviour, IPitcher
    {
        #region properties
        public Enum.DirectionY DirectionY { get; private set; }
        #endregion

        #region public methods
        public void OnFixedUpdate(float deltaTime)
        {
        }

        public void Setup(Enum.DirectionY directionY)
        {
            DirectionY = directionY;
        }

        /// <summary>
        /// 雪玉を投げる
        /// </summary>
        public void Throw(Snowball snowball)
        {
            snowball.Setup(DirectionY);
        }
        #endregion

        #region private methods
        #endregion
    }
}