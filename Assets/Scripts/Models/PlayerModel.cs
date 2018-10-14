using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FPS
{
    public class PlayerModel : BaseObjectScene
    {
        public static PlayerModel LocalPlayer { get; private set; }

        public BaseWeapon[] Weapons;

        [SerializeField]
        private int _maxHealth;

        private int _currentHelth;

        public int CurrentHelth { get { return _currentHelth; } }

        public float CurrentHelthForView { get { return (_currentHelth / _maxHealth); } }

        protected override void Awake()
        {
            if (LocalPlayer)
                DestroyImmediate(gameObject);
            else
                LocalPlayer = this;

            base.Awake();

            Weapons = GetComponentsInChildren<BaseWeapon>(true);

            _currentHelth = _maxHealth;
        }

        public void Damage(int damage)
        {
            if (_currentHelth <= 0)
                return;
            _currentHelth -= damage;

            if (_currentHelth <= 0)
            {
                if (OnPlayerDie != null)
                    OnPlayerDie.Invoke();
            }

        }

        public void Healing(int recoverableAmount)
        {
            if (_currentHelth == _maxHealth)
                return;
            if ((_currentHelth + recoverableAmount) >= _maxHealth)
                _currentHelth = _maxHealth;
            else
                _currentHelth += recoverableAmount;
        }

        public event UnityAction OnPlayerDie;
    }
}