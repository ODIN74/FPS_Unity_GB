using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class Bullet : BaseAmmo
    {
        [SerializeField]
        private float _destroyTime = 2f;
        [SerializeField]
        private LayerMask _layerMask;

        private bool _isHitted;
        private float _speed;
        private Vector3 _targetPoint;
        private ParticleSystem _particle;

        public override void Initialize(float force, Vector3 targetPoint)
        {
            _speed = force;
            _targetPoint = targetPoint;
            _particle = GetComponent<ParticleSystem>();
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
                    Destroy(gameObject, 0.3f);
                }
                else
                    Destroy(gameObject, 10f);

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