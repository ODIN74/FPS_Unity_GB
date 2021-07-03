using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
    public class CurrentBulletsCounterView : MonoBehaviour
    {
        private Text _text;
        private Canvas _canvas;

        private void Awake()
        {
            _text = GetComponent<Text>();
            _canvas = GetComponentInParent<Canvas>();
        }

        private void Update()
        {
            if(Main.Instance.WeaponController.CurrentWeapon is SingleBarreledFirearms)
            {
                _canvas.enabled = true;
                _text.text = string.Format("{0} / {1}",
                                          (Main.Instance.WeaponController.CurrentWeapon as SingleBarreledFirearms).CurrentNumberOfBullets,
                                          (Main.Instance.WeaponController.CurrentWeapon as SingleBarreledFirearms).CurrentNumberOfBulletsInClip);
            }

            if (Main.Instance.WeaponController.CurrentWeapon is MultiBarreledFirearms)
                _canvas.enabled = false;

        }
    }
}


