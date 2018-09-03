using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.SnowballFight
{
    public class SnowballPitcher : MonoBehaviour, IPitcher
    {
        #region variables
        [SerializeField]
        private Enum.Side m_side = Enum.Side.Player1;
        #endregion

        #region properties
        public Enum.DirectionY DirectionY { get; private set; }
        public Enum.Side Side { get { return m_side; } }

        private float ThrowTimer { get; set; } = 0;
        private float ThrowDelay { get; set; } = 99999;
        #endregion

        #region unity callbacks
        private void Awake()
        {
            Setup(m_side, 3);
        }

        private void FixedUpdate()
        {
            OnFixedUpdate(Time.deltaTime);
        }
        #endregion

        #region public methods
        public void Setup(Enum.Side side, float throwDelay)
        {
            // 雪玉投げタイマー設定
            ThrowDelay = throwDelay;
            ResetThrowTimer();
            // サイドを見て設定仕分け
            m_side = side;
            switch (side)
            {
                case Enum.Side.Player1:
                    DirectionY = Enum.DirectionY.Down;
                    break;
                case Enum.Side.Player2:
                    DirectionY = Enum.DirectionY.Up;
                    break;
            }
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void Damage(int damage)
        {
            Dead();
        }

        public void OnFixedUpdate(float deltaTime)
        {
            ThrowTimer -= deltaTime;
            if(ThrowTimer <= 0)
            {
                ResetThrowTimer();
                Throw();
            }
        }

        public Enum.Side GetSide() => Side;

        /// <summary>
        /// 雪玉を投げる
        /// </summary>
        public void Throw()
        {
            var snowball = Snowball.Create();
            snowball.Setup(DirectionY, Side);
            snowball.SetPosition(transform.position);
            snowball.Throw();
        }

        [ContextMenu("Throw")]
        public void TestThrow()
        {
            Setup(m_side, 10);
            Throw();
        }
        #endregion

        #region private methods
        private void Dead()
        {
            SetActive(false);
        }

        private void ResetThrowTimer()
        {
            var randomDelayAdd = UnityEngine.Random.Range(0, 1f);
            ThrowTimer = ThrowDelay + randomDelayAdd;
        }
        #endregion
    }
}