using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class BarrelModel : BaseEnveronmentObject
    {
        [SerializeField] private float force = 10.0f;

        public override void PlayerAction()
        {
            _rigidbody.AddForce(Vector3.forward * force, ForceMode.Impulse);
        }

    }
}
