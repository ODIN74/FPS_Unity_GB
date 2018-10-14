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

        public int RecoverableBullets
        {
            get
            {
                return recoverableBullets;
            }
        }

        public override void PlayerActionStop()
        {
            Destroy(transform.gameObject);
        }
    }
}


