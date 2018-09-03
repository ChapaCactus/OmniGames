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
        #endregion

        #region public methods
        public void Setup(Enum.Side side)
        {
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

        public void OnFixedUpdate(float deltaTime)
        {
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
            Setup(m_side);
            Throw();
        }
        #endregion

        #region private methods
        #endregion
    }
}