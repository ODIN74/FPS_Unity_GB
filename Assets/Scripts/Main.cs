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
        public List<BaseEnveronmentController> EnveronmentController { get; private set; } = new List<BaseEnveronmentController>();
        public BarrelController BarrelController { get; private set; }
        public WeaponController WeaponController { get; private set; }
        public TeammateController TeammateController { get; private set; }
        public DoorController DoorController { get; private set; }
        public MedicalKitController MedicalKitController { get; private set; }
        public AmmoCrateController AmmoCrateController { get; private set; } 

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
            EnveronmentController.Add((BarrelController = gameObject.AddComponent<BarrelController>()) as BaseEnveronmentController);
            WeaponController = gameObject.AddComponent<WeaponController>();
            TeammateController = gameObject.AddComponent<TeammateController>();
            EnveronmentController.Add((DoorController = gameObject.AddComponent<DoorController>()) as BaseEnveronmentController);
            EnveronmentController.Add((MedicalKitController = gameObject.AddComponent<MedicalKitController>()) as BaseEnveronmentController);
            EnveronmentController.Add((AmmoCrateController = gameObject .AddComponent<AmmoCrateController>()) as BaseEnveronmentController);
        }
    }
}
