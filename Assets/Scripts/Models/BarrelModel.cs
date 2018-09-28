﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class BarrelModel : BaseEnveronmentObject
    {
        [SerializeField] private float force = 100.0f;

        private bool _actionActive = false;

        public override void PlayerActionStart()
        {
            _actionActive = true;
            
        }

        public override void PlayerActionStop()
        {
            _actionActive = false;
        }

        private void Update()
        {
            if (_actionActive)
            {
                transform.position = _camera.transform.position + _camera.transform.forward* offsetZ + _camera.transform.up * offsetY;
            }
        }

    }
}
