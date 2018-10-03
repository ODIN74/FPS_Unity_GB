using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public abstract class BaseWeaponObject : BaseObjectScene {

        [SerializeField] protected int inflictedLoss;

        [SerializeField] protected int maxNumberOfBullets;

        [SerializeField] protected float shootingDistance;

        [SerializeField] protected float shootingAccuracy;

        protected int _currentNumberOfBullets;

        protected ParticleSystem _particle;

        protected override void Awake()
        {
            base.Awake();
            _particle = GetComponent<ParticleSystem>();

            if (_particle != null)
                _particle.Stop();
        }

        public int InflictedLoss
        {
            get { return inflictedLoss; }
        }

        protected virtual void Shot()
        {
            if(_particle != null)
                _particle.Play();
        }
    }
}

