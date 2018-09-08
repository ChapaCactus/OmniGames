using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG.WeaponSmith
{
    public class WeaponSmithScene : SceneBase
    {
        #region properties
        public Hammer Hammer { get; private set; }
        public Weapon Weapon { get; private set; }

        public int Score { get; private set; } = 0;

        private List<string> WeaponIDPool { get; set; }
        #endregion

        #region unity callbacks
        protected override void OnAwake()
        {
            base.OnAwake();

            WeaponIDPool = new List<string>()
            {
                "dagger01_black",
                "sword1h10_white",
                "axe2h12_grey",
            };
        }

        protected override void OnStart()
        {
            base.OnStart();

            Weapon = CreateWeapon();
            Hammer = new Hammer(this);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (Input.GetButtonDown("Jump"))
            {
                Enhance(Hammer.Power);
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                Delivery();
            }
        }
        #endregion

        #region public methods
        public void Delivery()
        {
            if (Weapon != null)
            {
                // スコア加算
                Score += Weapon.Score;
                // 武器再生成
                Weapon.Kill();
                Weapon = CreateWeapon();
            }
        }

        public void Enhance(int power)
        {
            Weapon.AddQuality(power);
        }
        #endregion

        #region private methods
        private Weapon CreateWeapon()
        {
            string id = WeaponIDPool.OrderBy(i => Guid.NewGuid())
                                    .FirstOrDefault();
            var weapon = new Weapon(id);
            return weapon;
        }
        #endregion
    }
}