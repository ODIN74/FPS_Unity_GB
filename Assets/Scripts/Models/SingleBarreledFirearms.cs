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

        private ParticleSystem _particle;

        protected override void Awake()
        {
            base.Awake();
            _particle = GetComponentInChildren<ParticleSystem>();
            if (_particle != null && _particle.isPlaying)
                _particle.Stop();
        }

        public override void Fire()
        {
            if (!TryShoot())
                return;
            base.Fire();
            _particle.Play();
            BaseAmmo bullet = PoolObjects.Instance.GetObject(_poolID) as BaseAmmo;
            bullet.Initialize(_force, _firepoint, targetPoint);
        }        

        public override void Reload()
        {
            //Реализуем в ДЗ
        }
    }
}