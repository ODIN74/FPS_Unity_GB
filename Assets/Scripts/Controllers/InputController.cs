using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class InputController : BaseController
    {
        private void Update()
        {
            if (Input.GetButtonDown("Flashlight Switch"))
                Main.Instance.FlashlightController.Switch();
            if (Input.GetButtonDown("Player Action"))
                Main.Instance.BarrelController.PlayerAction();
            if (Input.GetButton("Fire1"))
                Main.Instance.WeaponController.Fire();
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
                Main.Instance.WeaponController.ChangeWeapon(-1);
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
                Main.Instance.WeaponController.ChangeWeapon(1);
        }
    }
}
