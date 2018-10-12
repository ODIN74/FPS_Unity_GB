using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FPS
{
    public class AmmoCrateModel : BaseEnveronmentObject
    {
        [SerializeField]
        private int recoverableBullets = 25;

        protected override void Awake()
        {
            base.Awake();
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        public override void PlayerActionStart()
        {
            BulletsRecovery(recoverableBullets);
            Destroy(transform.gameObject);
        }

        public override void PlayerActionStop()
        {
        }

        public event UnityAction<int> BulletsRecovery;
    }
}


