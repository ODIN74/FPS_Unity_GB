using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS {

    public abstract class BaseEnemyObject : BaseObjectScene
    {
        [SerializeField] protected int lives;

        [SerializeField] protected int inflictedLoss;

        [SerializeField] protected float _speed;

        [SerializeField] protected float _attackDistance;   

        [SerializeField] protected float _patrolDistance;

        public int InflictedLoss
        {
            get { return inflictedLoss; }
        }

        public abstract void Attack();

        public abstract void Hit();

        protected abstract void Patrol();

        protected abstract void Die();
    }
}
