using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public abstract class BaseAmmo : BaseObjectScene
    {
        [SerializeField]
        protected float _damage = 20f;

        public abstract void Initialize(float force, Vector3 targetPoint);
    }
}