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
            _doorRB.freezeRotation = true;
        }

        private void Update()
        {
            if (!_doorHJ.useMotor)
                _doorHJ.useMotor = false;
        }

        public override void PlayerActionStart()
        {
            _doorRB.freezeRotation = false;
            _doorHJ.useMotor = true;
        }

        public override void PlayerActionStop()
        {
        }

    }
}


