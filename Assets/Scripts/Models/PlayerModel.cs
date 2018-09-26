using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class PlayerModel : BaseObjectScene
    {
        public static PlayerModel LocalPlayer { get; private set; }

        public BaseWeapon[] Weapons;

        protected override void Awake()
        {
            if (LocalPlayer)
                DestroyImmediate(gameObject);
            else
                LocalPlayer = this;

            base.Awake();

            Weapons = GetComponentsInChildren<BaseWeapon>(true);
        }
    }
}