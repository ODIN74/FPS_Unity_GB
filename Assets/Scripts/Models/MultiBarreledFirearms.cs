using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class MultiBarreledFirearms : BaseWeapon
    {
        [SerializeField]
        private Transform[] _firepoints;
        private int _currentFirepoint;

        public override void Fire()
        {
            if (!TryShoot())
                return;
            base.Fire();
            BaseAmmo bullet = Instantiate(_ammoPrefab, _firepoints[_currentFirepoint].position, _firepoints[_currentFirepoint].rotation);
            bullet.Initialize(_force, targetPoint);

            _currentFirepoint++;
            if (_currentFirepoint >= _firepoints.Length)
                _currentFirepoint = 0;
        }

        public override void Reload()
        {
            //Реализуем в ДЗ
        }
    }
}