using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class WeaponController : BaseController
    {
        private BaseWeapon[] _weapons;
        private int _currentWeapon;

        private void Awake()
        {
            _weapons = PlayerModel.LocalPlayer.Weapons;

            for (int i = 0; i < _weapons.Length; i++)
                _weapons[i].IsVisible = i == 0;
        }

        public void ChangeWeapon(int i)
        {
            _weapons[_currentWeapon].IsVisible = false;
            _currentWeapon += i;
            if (_currentWeapon >= _weapons.Length)
                _currentWeapon = 0;
            if (_currentWeapon < 0)
                _currentWeapon = _weapons.Length - 1;
            _weapons[_currentWeapon].IsVisible = true;
        }

        public void Fire()
        {
            if (_weapons.Length > _currentWeapon && _weapons[_currentWeapon])
                _weapons[_currentWeapon].Fire();
        }
    }
}