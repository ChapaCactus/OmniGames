using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.SnowballFight
{
    public interface IPitcher
    {
        #region public methods
        void Throw();
        void OnFixedUpdate(float deltaTime);

        Enum.Side GetSide();
        #endregion
    }
}