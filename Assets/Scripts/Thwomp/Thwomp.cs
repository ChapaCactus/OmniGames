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

        #region properties
        public ActionState CurrentActionState { get; private set; }

        private Vector2 StartPos { get; set; }
        private Vector2 EndPos { get; set; }
        #endregion

        #region unity callbacks
        private void Awake()
        {
            StartPos = transform.position;
            EndPos = transform.position + new Vector3(0, -7, 0);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Action();
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
            moveSeq.Append(
                transform.DOMove(EndPos, 0.5f)
                .SetEase(Ease.InQuint)
                .OnComplete(() =>
            {
                CurrentActionState = ActionState.Leaving;
            }));
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
    }
}