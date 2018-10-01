using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class Bullet : BaseAmmo
    {
        [SerializeField]
        private float _destroyTime = 0.3f;
        [SerializeField]
        private LayerMask _layerMask;

        [SerializeField]
        private string _poolID = "Bullet01";
        [SerializeField]
        private int _bulletsCount = 50;

        private bool _isHitted;
        private float _speed;
        private Vector3 _targetPoint;
        private ParticleSystem _particle;

        public override string PoolID { get { return _poolID; } }

        public override int countOjects { get { return _bulletsCount; } }

        public override void Initialize(float force, Transform firePointTransform, Vector3 targetPoint)
        {
            transform.position = firePointTransform.position;
            transform.rotation = firePointTransform.rotation;

            CancelInvoke();
            _isHitted = false;
            _speed = force;
            _targetPoint = targetPoint;
            _particle = GetComponentInParent<ParticleSystem>();
            Invoke("DisableInstance", _destroyTime);
            gameObject.SetActive(true);
        }


        private void FixedUpdate()
        {

            if (_isHitted)
                return;

            Vector3 finalPos = transform.position + (_targetPoint - transform.position).normalized * _speed * Time.fixedDeltaTime;
            RaycastHit hit;
            if (Physics.Linecast(transform.position, finalPos, out hit, _layerMask))
            {
                _isHitted = true;
                transform.position = hit.point;

                if(_particle)
                {
                    _particle.Play();
                    DisableInstance();
                }
                else
                    DisableInstance();

                IDamageable d = hit.collider.GetComponent<IDamageable>();                
                if (d != null)
                    d.ApplyDamage(_damage);
            }
            else
            {
                transform.position = finalPos;
            }
        }        
    }
}