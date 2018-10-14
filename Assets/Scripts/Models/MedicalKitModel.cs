using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FPS
{
    public class MedicalKitModel : BaseEnveronmentObject
    {
        [SerializeField]
        private int recoverableAmount = 10;

        public int RecoverableAmount
        {
            get
            {
                return recoverableAmount;
            }
        }

        public override void PlayerActionStart()
        {
            Destroy(transform.gameObject);
        }

        public override void PlayerActionStop()
        {
        }
    }
}
