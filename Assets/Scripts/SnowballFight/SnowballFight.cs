using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG.SnowballFight
{
    public class SnowballFight : MonoBehaviour
    {
        #region properties
        public List<IPitcher> Player1Pitchers { get; private set; }
        public List<IPitcher> Player2Pitchers { get; private set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            Player1Pitchers = new List<IPitcher>();
            Player2Pitchers = new List<IPitcher>();
        }

        private void FixedUpdate()
        {
            float deltaTime = Time.deltaTime;
            Player1Pitchers.ForEach(pitcher => pitcher.OnFixedUpdate(deltaTime));
            Player2Pitchers.ForEach(pitcher => pitcher.OnFixedUpdate(deltaTime));
        }
        #endregion
    }
}