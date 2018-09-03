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
        public List<IPitcher> PlayerPitchers { get; private set; }
        public List<IPitcher> EnemyPitchers { get; private set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            PlayerPitchers = new List<IPitcher>();
            EnemyPitchers = new List<IPitcher>();
        }

        private void FixedUpdate()
        {
            float deltaTime = Time.deltaTime;
            PlayerPitchers.ForEach(pitcher => pitcher.OnFixedUpdate(deltaTime));
            EnemyPitchers.ForEach(pitcher => pitcher.OnFixedUpdate(deltaTime));
        }
        #endregion
    }
}