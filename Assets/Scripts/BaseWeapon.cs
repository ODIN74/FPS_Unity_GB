using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

namespace FPS
{
    public abstract class BaseWeapon : BaseObjectScene
    {
        [SerializeField]
        protected string _poolID;
        [SerializeField]
        protected float _force;
        [SerializeField]
        protected float _reloadTime;
        private float _reloadTimer;

        [SerializeField]
        protected float _timeout;
        protected float _lastShotTime;

        private Camera _mainCamera;
        protected Vector3 targetPoint;

        protected Animator _anim;
        protected ParticleSystem _particle;

        protected override void Awake()
        {
            base.Awake();
            _mainCamera = Camera.main;
            _particle = GetComponentInChildren<ParticleSystem>();
            _anim = GetComponent<Animator>();
        }

        public virtual void Fire()
        {
            var raycastStartPoint = new Vector3(_mainCamera.pixelWidth / 2, _mainCamera.pixelHeight / 2, 0);
            var ray = _mainCamera.ScreenPointToRay(raycastStartPoint);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            targetPoint = hit.point;
            if (_particle != null)
                _particle.Play();
            if (_anim != null)
                _anim.SetTrigger("Fire");
        }

        protected bool TryShoot()
        {

            if (Time.time - _lastShotTime < _timeout)
                return false;

            _lastShotTime = Time.time;
            return true;
        }

        public abstract void Reload();
    }
}