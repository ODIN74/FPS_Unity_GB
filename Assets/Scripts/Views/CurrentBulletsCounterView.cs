using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
    public class CurrentBulletsCounterView : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Start()
        {
            _text.text = string.Format("{0} / {1}",
                (Main.Instance.WeaponController.CurrentWeapon as SingleBarreledFirearms)?.CurrentNumberOfBullets,
                (Main.Instance.WeaponController.CurrentWeapon as SingleBarreledFirearms)?.CurrentNumberOfBulletsInClip);
        }

        private void Update()
        {
            _text.text = string.Format("{0} / {1}",
                (Main.Instance.WeaponController.CurrentWeapon as SingleBarreledFirearms).CurrentNumberOfBullets,
                (Main.Instance.WeaponController.CurrentWeapon as SingleBarreledFirearms).CurrentNumberOfBulletsInClip);
        }
    }
}


