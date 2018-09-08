using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.WeaponSmith
{
    public class Hammer
    {
        #region properties
        public WeaponSmithScene ParentScene { get; private set; }

        public int Power { get; private set; } = 1;
        #endregion

        #region public methods
        public Hammer(WeaponSmithScene parentScene)
        {
            ParentScene = parentScene;
        }
        #endregion

        #region private methods
        private Weapon GetCurrentWeapon()
        {
            return ParentScene.Weapon;
        }
        #endregion
    }
}