using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.WeaponSmith
{
    public class Weapon
    {
        #region properties
        public string ID { get; private set; }

        public int Rarity { get; private set; } = 1;
        public int Quality { get; private set; } = 1;

        public int Score { get { return (int)((Rarity + Quality) * 1.25f); } }

        public GameObject GameObject { get; private set; }
        #endregion

        #region public methods
        public Weapon(string id)
        {
            ID = id;

            GameObject = CreateGameObject();
        }

        public void AddQuality(int add)
        {
            Quality++;
        }

        public void Kill()
        {
            UnityEngine.GameObject.Destroy(this.GameObject);
        }
        #endregion

        #region private methods
        private GameObject CreateGameObject()
        {
            var prefabPath = $"WeaponSmith/Prefabs/Weapon/{ID}";
            var prefab = Resources.Load(prefabPath) as GameObject;
            var go = UnityEngine.GameObject.Instantiate(prefab, null);

            return go;
        }
        #endregion
    }
}