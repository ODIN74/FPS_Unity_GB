using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class Main : MonoBehaviour
    {
        public static Main Instance { get; private set; }

        public InputController InputController { get; private set; }
        public FlashlightController FlashlightController { get; private set; }
        public BarrelController BarrelController { get; private set; }
        public WeaponController WeaponController { get; private set; }
        public TeammateController TeammateController { get; private set; }

        private void Awake()
        {
            if (Instance)
                DestroyImmediate(this);
            else
                Instance = this;
        }

        private void Start()
        {
            InputController = gameObject.AddComponent<InputController>();
            FlashlightController = gameObject.AddComponent<FlashlightController>();
            BarrelController = gameObject.AddComponent<BarrelController>();
            WeaponController = gameObject.AddComponent<WeaponController>();
            TeammateController = gameObject.AddComponent<TeammateController>();
        }
    }
}
