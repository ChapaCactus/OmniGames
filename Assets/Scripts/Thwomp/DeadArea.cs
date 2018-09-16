using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class DeadArea : MonoBehaviour
    {
        #region unity callbacks
        private void OnTriggerExit2D(Collider2D collision)
        {
            var go = collision.gameObject;
            Destroy(go);
        }
        #endregion
    }
}