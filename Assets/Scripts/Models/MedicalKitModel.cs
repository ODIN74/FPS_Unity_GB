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

        protected override void Awake()
        {
            base.Awake();
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        public override void PlayerActionStart()
        {
            HealthRecovery(recoverableAmount);
            Destroy(transform.gameObject);
        }

        public override void PlayerActionStop()
        {
        }

        public event UnityAction<int> HealthRecovery;
    }
}
