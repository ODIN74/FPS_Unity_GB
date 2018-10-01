using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class SingleBarreledFirearms : BaseWeapon
    {
        [SerializeField]
        private Transform _firepoint;

        protected override void Awake()
        {
            base.Awake();
            if (_particle != null && _particle.isPlaying)
                _particle.Stop();
        }

        public override void Fire()
        {
            if (!TryShoot())
                return;
            base.Fire();
            
            BaseAmmo bullet = PoolObjects.Instance.GetObject(_poolID) as BaseAmmo;
            bullet.Initialize(_force, _firepoint, targetPoint);
        }        

        public override void Reload()
        {
            //Реализуем в ДЗ
        }
    }
}