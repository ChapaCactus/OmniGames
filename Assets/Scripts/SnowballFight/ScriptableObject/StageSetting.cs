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
        // 1P用壁配置設定
        [SerializeField]
        private List<Vector2> m_player1WallPositionList = new List<Vector2>();
        // 2P用壁配置設定
        [SerializeField]
        private List<Vector2> m_player2WallPositionList = new List<Vector2>();
        #endregion

        #region public methods
        /// <summary>
        /// 指定したPlayer側の雪壁座標リストを返す
        /// </summary>
        public List<Vector2> GetPlayerWallPositionList(Enum.Side side)
        {
            return (side == Enum.Side.Player1) ? GetPlayer1WallPositionList() : GetPlayer2WallPositionList();
        }
        #endregion

        #region private methods
        /// <summary>
        /// 壁配置リストに要素が設定されていない時など、適当な値を入れて返す
        /// </summary>
        private List<Vector2> GetDummyWallPositionList(Enum.Side side)
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

        /// <summary>
        /// 1P用壁座標リストを返す
        /// 設定されて居なければダミーを返す
        /// </summary>
        private List<Vector2> GetPlayer1WallPositionList()
        {
            if (m_player1WallPositionList.Count == 0)
            {
                return GetDummyWallPositionList(Enum.Side.Player1);
            }
            else
            {
                return m_player1WallPositionList;
            }
        }

        /// <summary>
        /// 2P用壁座標リストを返す
        /// 設定されて居なければダミーを返す
        /// </summary>
        private List<Vector2> GetPlayer2WallPositionList()
        {
            if (m_player2WallPositionList.Count == 0)
            {
                return GetDummyWallPositionList(Enum.Side.Player2);
            }
            else
            {
                return m_player2WallPositionList;
            }
        }
        #endregion
    }
}