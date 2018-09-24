using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class BarrelModel : BaseEnveronmentObject
    {
        [SerializeField] private float force = 100.0f;

        public override void PlayerAction()
        {
            _rigidbody.AddForce((transform.position - Player.transform.position) * force, ForceMode.Impulse);
        }

    }
}
