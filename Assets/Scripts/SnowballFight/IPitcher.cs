using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.SnowballFight
{
    public interface IPitcher
    {
        #region public methods
        void Throw(Snowball snowball);
        void OnFixedUpdate(float deltaTime);
        #endregion
    }
}