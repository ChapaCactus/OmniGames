using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG.SnowballFight
{
    public class Snowball : MonoBehaviour
    {
        #region constants
        private const float MOVE_BUFF = 0.2f;
        #endregion

        #region properties
        public Enum.DirectionY DirectionY { get; private set; }
        public Vector3 MoveVector { get; private set; } = Vector3.zero;
        public float Speed { get; private set; }

        public Enum.Side OwnerSide { get; private set; }

        public bool IsPlaying { get; private set; } = false;
        #endregion

        #region unity callbacks
        private void FixedUpdate()
        {
            if (!IsPlaying)
                return;

            transform.position += (MoveVector * Speed * MOVE_BUFF);
        }
        #endregion

        #region public methods
        public static Snowball Create()
        {
            var prefab = Resources.Load<Snowball>("Snowball/Prefabs/Item/Snowball");
            return Instantiate(prefab, null);
        }

        public void Setup(Enum.DirectionY dirY, Enum.Side ownerSide, float speed = 1)
        {
            OwnerSide = ownerSide;

            DirectionY = dirY;
            Speed = speed;
            switch (dirY)
            {
                case Enum.DirectionY.Up:
                    MoveVector = Vector3.up;
                    break;
                case Enum.DirectionY.Down:
                    MoveVector = Vector3.down;
                    break;
            }
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        public void Throw()
        {
            IsPlaying = true;
            SetActive(true);
        }

        [ContextMenu("TestThrow")]
        public void TestThrow()
        {
            Setup(Enum.DirectionY.Up, Enum.Side.Player1, 1);
            Throw();
        }
        #endregion

        #region private methods
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var tag = collision.tag;
            switch (tag)
            {
                case "Worker":
                    var pitcher = collision.gameObject.GetComponent<IPitcher>();
                    if (OwnerSide != pitcher.GetSide())
                    {
                        pitcher.Damage(1);
                        // 敵と衝突
                        Kill();
                    }
                    break;
                case "Bullet":
                    Kill();
                    var snowball = collision.gameObject.GetComponent<Snowball>();
                    snowball.Kill();// 念の為相手のKillも呼ぶ
                    break;
                case "Wall":
                    Kill();
                    break;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Area"))
            {
                // 戦場から出た場合、消す
                Kill();
            }
        }

        private void Kill()
        {
            IsPlaying = false;
            SetActive(false);
        }
        #endregion
    }
}