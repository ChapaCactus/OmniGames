using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using DG.Tweening;

namespace CCG.Thwomp
{
    public class Thwomp : MonoBehaviour
    {
        #region enums
        public enum ActionState
        {
            Wait,
            Moving,
            Leaving,
        }
        #endregion

        #region constants
        private const string TARGET_TAG = "NPC";
        #endregion

        #region properties
        public ActionState CurrentActionState { get; private set; }

        private Vector2 StartPos { get; set; }
        private Vector2 EndPos { get; set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            StartPos = transform.position;
            EndPos = transform.position + new Vector3(0f, -7.3f, 0f);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Action();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var go = collision.gameObject;
            if (go.CompareTag(TARGET_TAG))
            {
                // NPC削除
                Destroy(go);
                AddReward(-1);
            }
        }
        #endregion

        #region public methods
        public void Action()
        {
            if (CurrentActionState == ActionState.Moving
                || CurrentActionState == ActionState.Leaving)
            {
                return;
            }

            CurrentActionState = ActionState.Moving;

            transform.position = StartPos;
            var moveSeq = DOTween.Sequence();
            // 下移動
            moveSeq.Append(
                transform.DOMove(EndPos, 0.5f)
                .SetEase(Ease.InQuint)
                .OnComplete(() =>
            {
                CurrentActionState = ActionState.Leaving;
            }));
            // 上移動
            moveSeq.Append(
                transform.DOMove(StartPos, 0.5f)
                .SetDelay(0.5f)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
            {
                CurrentActionState = ActionState.Wait;
            }));

            Debug.Log("Action");
        }
        #endregion

        #region private methods
        private void AddReward(int add)
        {
        }
        #endregion
    }
}