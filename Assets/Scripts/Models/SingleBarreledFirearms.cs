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

        [SerializeField]
        private int _maxCountOfBullets = 300;

        [SerializeField]
        private int _numberBulletsInClip = 30;

        private int _currentNumberOfBulletsInClip = 0;
        public int CurrentNumberOfBulletsInClip { get { return _currentNumberOfBulletsInClip; } }

        private int _currentNumberOfBullets = 0;
        public int CurrentNumberOfBullets { get { return _currentNumberOfBullets; } }

        private bool _rechargeFlag = false;

        protected override void Awake()
        {
            base.Awake();
            if (_particle != null && _particle.isPlaying)
                _particle.Stop();
            _currentNumberOfBullets = _maxCountOfBullets;
            _currentNumberOfBulletsInClip = _numberBulletsInClip;
            _currentNumberOfBullets -= _currentNumberOfBulletsInClip;
        }

        protected void FixedUpdate()
        {
            if (_anim != null)
                _anim.SetInteger("numberBullets", _currentNumberOfBulletsInClip);

            if (_currentNumberOfBulletsInClip == 0 && !_rechargeFlag && _currentNumberOfBullets != 0 && !_anim.GetCurrentAnimatorStateInfo(0).IsName("Recharge"))
            {
                _anim.SetTrigger("Recharge");
                _rechargeFlag = true;
                Recharge();
            }
        }

        public override void Fire()
        {
            if (!TryShoot())
                return;
            base.Fire();

            BaseAmmo bullet = PoolObjects.Instance.GetObject(_poolID) as BaseAmmo;
            bullet.Initialize(_force, _firepoint, targetPoint);
            if (_currentNumberOfBulletsInClip > 0)
                _currentNumberOfBulletsInClip--;
        }

        public override void Recharge()
        {
            if (_currentNumberOfBulletsInClip != 0)
            {
                if (_anim != null)
                    _anim.SetTrigger("Recharge");
                StartCoroutine(RechargeDelay());
            }
            else
            {
                StartCoroutine(RechargeDelay());
            }
            Debug.Log(_currentNumberOfBullets);
            _rechargeFlag = false;
        }

        IEnumerator RechargeDelay()
        {
            yield return new WaitForSeconds(_reloadTime);
            if (_currentNumberOfBulletsInClip != 0)
            {
                _currentNumberOfBullets -= (_numberBulletsInClip - _currentNumberOfBulletsInClip);
                _currentNumberOfBulletsInClip = _numberBulletsInClip;
            }
            else if (_currentNumberOfBullets <= _numberBulletsInClip)
            {
                _currentNumberOfBulletsInClip = _currentNumberOfBullets;
                _currentNumberOfBullets = 0;
            }
            else
            {
                _currentNumberOfBulletsInClip = _numberBulletsInClip;
                _currentNumberOfBullets -= _numberBulletsInClip;
            }
            _anim.ResetTrigger("Recharge");
            StopCoroutine(RechargeDelay());
        }
    }
}