using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.WeaponSmith
{
    public class PartyMember
    {
        #region enums
        public enum State
        {
            Wait,
            Battle,
            Finish,
        }
        #endregion

        #region properties
        public Weapon Weapon { get; private set; }

        public State CurrentState { get; private set; }
        #endregion

        #region public methods
        public void SetWeapon(Weapon weapon)
        {
            Weapon = weapon;
        }

        public void OnFinishBattle()
        {
            Weapon = null;
            CurrentState = State.Finish;
        }
        #endregion
    }
}