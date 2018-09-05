using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.SnowballFight
{
    /// <summary>
    /// ステージ設定用
    /// </summary>
    [CreateAssetMenu(menuName = "SnowballFight/ScriptableObject/StageSetting")]
    public class StageSetting : ScriptableObject
    {
        #region variables
        [SerializeField]
        private List<Vector2> m_player1WallList = new List<Vector2>();
        [SerializeField]
        private List<Vector2> m_player2WallList = new List<Vector2>();
        #endregion

        #region public methods
        public List<Vector2> GetPlayer1WallList()
        {
            if (m_player1WallList.Count == 0)
            {
                return GetDummyWallList(Enum.Side.Player1);
            }
            else
            {
                return m_player1WallList;
            }
        }

        public List<Vector2> GetPlayer2WallList()
        {
            if (m_player2WallList.Count == 0)
            {
                return GetDummyWallList(Enum.Side.Player2);
            }
            else
            {
                return m_player2WallList;
            }
        }
        #endregion

        #region private methods
        private List<Vector2> GetDummyWallList(Enum.Side side)
        {
            var dummy = new List<Vector2>();
            switch(side)
            {
                case Enum.Side.Player1:
                    dummy = new List<Vector2>()
                    {
                        new Vector2(0f, 1f),
                        new Vector2(1.5f, 2f),
                        new Vector2(-1.5f, 2f),
                    };
                    break;
                case Enum.Side.Player2:
                    dummy = new List<Vector2>()
                    {
                        new Vector2(0f, -1f),
                        new Vector2(1.5f, -2f),
                        new Vector2(-1.5f, -2f),
                    };
                    break;
            }

            return dummy;
        }
        #endregion
    }
}