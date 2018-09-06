using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG.SnowballFight
{
    /// <summary>
    /// ステージ管理
    /// </summary>
    public class StageManager
    {
        #region properties
        public StageSetting StageSetting { get; private set; }

        public List<SnowWall> Side1Walls { get; private set; }
        public List<SnowWall> Side2Walls { get; private set; }
        #endregion

        #region public methods
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StageManager(StageSetting stageSetting)
        {
            StageSetting = stageSetting;

            Side1Walls = new List<SnowWall>();
            Side2Walls = new List<SnowWall>();
        }

        /// <summary>
        /// 雪壁生成
        /// </summary>
        public void CreateWalls()
        {
            Side1Walls = new List<SnowWall>();
            StageSetting.GetPlayerWallPositionList(Enum.Side.Player1)
                                     .ForEach(pos =>
                                     {
                                         var prefab = Resources.Load<SnowWall>("Snowball/Prefabs/SnowWall");
                                         var wall = GameObject.Instantiate(prefab, null);
                                         wall.transform.position = pos;
                                         Side1Walls.Add(wall);
                                     });
            Side2Walls = new List<SnowWall>();
            StageSetting.GetPlayerWallPositionList(Enum.Side.Player2)
                                     .ForEach(pos =>
                                     {
                                         var prefab = Resources.Load<SnowWall>("Snowball/Prefabs/SnowWall");
                                         var wall = GameObject.Instantiate(prefab, null);
                                         wall.transform.position = pos;
                                         Side2Walls.Add(wall);
                                     });
        }
        #endregion

        #region private methods
        #endregion
    }
}