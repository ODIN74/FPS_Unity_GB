using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FPS
{
    public class MultiBarreledFirearms : BaseWeapon
    {
        [SerializeField]
        private Transform[] _firepoints;

        [SerializeField]
        private float alternativeFireDelay = 5.0f;

        private int _currentFirepoint;

        private float _lastAltShotTime;

        private bool _coroutineStarted = false;

        private float energy;

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

        public static UnityAction<float> OnAlternativeFire;

        public void AlternativeFireStart()
        {  
            if(!_coroutineStarted)
            {
                base.Fire();
                StartCoroutine(MultiFire());
            }
        }

        public void AlternativeFireStop()
        {
            StopAllCoroutines();
            _coroutineStarted = false;
            energy = 0.0f;
            if (OnAlternativeFire != null)
                OnAlternativeFire(energy);
        }

        public override void Reload()
        {
            //Реализуем в ДЗ
        }

        IEnumerator MultiFire()
        {
            energy = 0.0f;
            _coroutineStarted = true;
            do
            {
                yield return new WaitForSeconds(alternativeFireDelay / 5);
                energy += 0.2f;
                if(OnAlternativeFire != null)
                    OnAlternativeFire(energy);
            }
            while (energy < 1);

            foreach (var point in _firepoints)
            {
                BaseAmmo bullet = Instantiate(_ammoPrefab, point.position, point.rotation);
                bullet.Initialize(_force, targetPoint);
            }
            _coroutineStarted = false;
        }
    }
}