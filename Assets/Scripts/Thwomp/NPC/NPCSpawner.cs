using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG.Thwomp
{
    public class NPCSpawner : MonoBehaviour
    {
        #region variables
        [SerializeField]
        private List<GameObject> m_spawnPosList = new List<GameObject>();

        [SerializeField]
        private float m_spawnDelay = 5f;
        #endregion

        #region properties
        private float Timer { get; set; } = 1f;
        #endregion

        #region unity callbacks
        private void Update()
        {
            Timer -= Time.deltaTime;
            if(Timer <= 0)
            {
                SpawnNPC();
                Timer = m_spawnDelay;
            }
        }
        #endregion

        #region private methods
        private void SpawnNPC()
        {
            var prefab = Resources.Load<NPC>("Thwomp/Prefabs/NPC");
            var npc = Instantiate(prefab, null);
            npc.transform.position = GetSpawnPosAtRandom().transform.position;
            npc.OnSpawn();
        }

        private GameObject GetSpawnPosAtRandom()
        {
            return m_spawnPosList.OrderBy(i => Guid.NewGuid())
                                 .FirstOrDefault();
        }
        #endregion
    }
}