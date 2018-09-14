using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using System.Linq;

namespace CCG.WeaponSmith
{
    public class PieceMap
    {
        #region properties
        public List<PuzzlePiece> Pieces { get; private set; } = new List<PuzzlePiece>();

        public Transform PieceParent { get; private set; }
        #endregion

        #region public methods
        public void Setup(Transform pieceParent, List<PuzzlePiece> pieces)
        {
            Reset();
            PieceParent = pieceParent;

            foreach(var loopIndex in Enumerable.Range(0, 25))
            {
                var piece = pieces[loopIndex];
                Pieces.Add(piece);
            }
        }

        public void Reset()
        {
            Pieces.Clear();
        }

        public void Build()
        {
        }

        public List<PuzzlePiece> GetPiecesType(string type)
        {
            return Pieces.Where(piece => piece.Type == type)
                         .ToList();
        }
        #endregion
    }
}