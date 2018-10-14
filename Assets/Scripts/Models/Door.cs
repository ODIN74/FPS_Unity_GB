using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class Door : BaseEnveronmentObject
    {
        private HingeJoint _doorHJ;
        private Rigidbody _doorRB;

        protected override void Awake()
        {
            base.Awake();
            _doorHJ = gameObject.GetComponent<HingeJoint>();
            _doorRB = gameObject.GetComponent<Rigidbody>();
            _doorRB.constraints = RigidbodyConstraints.FreezeAll;
        }

        private void FixedUpdate()
        {
            if (transform.localRotation.eulerAngles.z >= 89)
            {
                _doorHJ.useMotor = false;
                _doorRB.constraints = RigidbodyConstraints.FreezeAll;
            }
        }

        public override void PlayerActionStart()
        {
            _doorRB.constraints = RigidbodyConstraints.None;
            _doorHJ.useMotor = true;
        }

        public override void PlayerActionStop()
        {
        }
    }
}


