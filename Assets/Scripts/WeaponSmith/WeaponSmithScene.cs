using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG.WeaponSmith
{
    public class WeaponSmithScene : SceneBase
    {
        #region variables
        [SerializeField]
        private Transform m_pieceParent = null;
        [SerializeField]
        private List<PuzzlePiece> m_pieces = new List<PuzzlePiece>();
        #endregion

        #region properties
        public int Score { get; private set; } = 0;

        public PieceMap PieceMap { get; private set; }
        #endregion

        #region unity callbacks
        protected override void OnAwake()
        {
            base.OnAwake();

            PieceMap = new PieceMap();
            PieceMap.Setup(m_pieceParent, m_pieces);
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
        }
        #endregion

        #region public methods
        /// <summary>
        /// ピース盤面の組み立て
        /// </summary>
        public void BuildPieceMap()
        {
            PieceMap.Build();
        }
        #endregion

        #region private methods
        #endregion
    }
}