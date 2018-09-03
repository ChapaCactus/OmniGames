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
        public void Setup(Enum.DirectionY dirY, float speed = 1)
        {
            DirectionY = dirY;
            Speed = speed;
            switch(dirY)
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

        public void Throw()
        {
            IsPlaying = true;
            SetActive(true);
        }

        [ContextMenu("TestThrow")]
        public void TestThrow()
        {
            Setup(Enum.DirectionY.Up, 1);
            Throw();
        }
        #endregion

        #region private methods
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Worker"))
            {
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