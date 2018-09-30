using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public abstract class BaseAmmo : BaseObjectScene, IPoolable
    {
        [SerializeField]
        protected float _damage = 20f;

        public abstract string PoolID { get; }

        public abstract int countOjects { get; }

        public abstract void Initialize(float force, Transform firePointTransform, Vector3 targetPoint);

        public virtual void DisableInstance()
        {
            gameObject.SetActive(false);
        }
    }
}