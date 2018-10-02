using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;


namespace FPS
{
    public class EnemyBot : BaseObjectScene, IDamageable
    {
        [SerializeField]
        private float speed = 10.0f;

        [SerializeField]
        private float timeFromStandToIdle = 1.0f;

        [SerializeField]
        private float destroyDelay = 1.0f;

        [SerializeField]
        private bool enableRandomPosition = true;

        [SerializeField]
        private float maxHealth;

        public float MaxHelth { get { return maxHealth; } }

        private float currentHelth = 0;

        public float CurrentHealth { get { return currentHelth; } }

        private Animator _anim;

        private Transform _eyesTransform;

        private Vector3 _randomPosition;

        private Transform _targetTransform;

        private bool targetVisibility;

        protected override void Awake()
        {
            base.Awake();
            _anim = GetComponent<Animator>();
            currentHelth = maxHealth;
            Transform[] transformArray = GetComponentsInChildren<Transform>();
            foreach (var tr in transformArray)
            {
                if (tr.tag.Equals("Eyes"))
                {
                    _eyesTransform = tr;
                    break;
                }
            }
            Debug.Log(_eyesTransform.position);
        }

        private void Update()
        {
            if (_anim && _anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
                StartCoroutine(FromStandToIdleDelay(timeFromStandToIdle));
        }

        private IEnumerator FromStandToIdleDelay(float timeFromStandToIdle)
        {
            yield return new WaitForSeconds(timeFromStandToIdle);
            _anim.SetTrigger("Idle");
            StopCoroutine(FromStandToIdleDelay(timeFromStandToIdle));
        }

        public void ApplyDamage(float damage)
        {
            if (currentHelth <= 0)
                return;

            
            currentHelth -= damage;

            if (currentHelth <= 0)
                Death();

            if (_anim)
            _anim.SetTrigger("Damage");
        }

        public void Death()
        {
            _anim.SetTrigger("Death");
            Destroy(gameObject, destroyDelay);
        } 
    }

}