using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG.SnowballFight
{
    public class FightSetupData
    {
        public List<CharacterSetupData> Player1SetupData { get; set; }
        public List<CharacterSetupData> Player2SetupData { get; set; }
    }

    public class CharacterSetupData
    {
        public string PrefabName { get; set; }
        public Vector2 Position { get; set; }

        public CharacterSetupData(string prefabName, Vector2 position)
        {
            PrefabName = prefabName;
            Position = position;
        }
    }

    public class SnowballFightScene : MonoBehaviour
    {
        #region properties
        public List<IPitcher> Player1Pitchers { get; private set; }
        public List<IPitcher> Player2Pitchers { get; private set; }

        public StageManager StageManager { get; private set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            Player1Pitchers = new List<IPitcher>();
            Player2Pitchers = new List<IPitcher>();

            var setupData = new FightSetupData();
            setupData.Player1SetupData = new List<CharacterSetupData>()
            {
                new CharacterSetupData("", new Vector2(1, 4)),
                new CharacterSetupData("", new Vector2(0, 4)),
                new CharacterSetupData("", new Vector2(-1, 4)),
                new CharacterSetupData("", new Vector2(1, 3)),
                new CharacterSetupData("", new Vector2(0, 3)),
                new CharacterSetupData("", new Vector2(-1, 3)),
            };
            setupData.Player2SetupData = new List<CharacterSetupData>()
            {
                new CharacterSetupData("", new Vector2(1, -4)),
                new CharacterSetupData("", new Vector2(0, -4)),
                new CharacterSetupData("", new Vector2(-1, -4)),
                new CharacterSetupData("", new Vector2(1, -3)),
                new CharacterSetupData("", new Vector2(0, -3)),
                new CharacterSetupData("", new Vector2(-1, -3)),
            };
            Setup(setupData);

            var stageSetting = Resources.Load("Snowball/ScriptableObject/Stage1") as StageSetting;
            StageManager = new StageManager(stageSetting);
            StageManager.CreateWalls();
        }

        private void FixedUpdate()
        {
            float deltaTime = Time.deltaTime;
            Player1Pitchers.ForEach(pitcher => pitcher.OnFixedUpdate(deltaTime));
            Player2Pitchers.ForEach(pitcher => pitcher.OnFixedUpdate(deltaTime));
        }
        #endregion

        #region public methods
        public void Setup(FightSetupData setupData)
        {
            // Player1生成
            setupData.Player1SetupData.ForEach(data =>
            {
                var prefab = Resources.Load<SnowballPitcher>("Snowball/Prefabs/Character/Spaceman");
                var chara = Instantiate(prefab, null);
                chara.Setup(Enum.Side.Player1, 3);
                chara.SetPosition(data.Position);
            });
            // Player2生成
            setupData.Player2SetupData.ForEach(data =>
            {
                var prefab = Resources.Load<SnowballPitcher>("Snowball/Prefabs/Character/Spaceman");
                var chara = Instantiate(prefab, null);
                chara.Setup(Enum.Side.Player2, 3);
                chara.SetPosition(data.Position);
            });
        }
        #endregion
    }
}