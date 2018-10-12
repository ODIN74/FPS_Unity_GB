using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class MedicalKitController : BaseEnveronmentController
    {
        private MedicalKitModel[] _medikalKits;

        private PlayerActionView _view;

        private MedicalKitModel _objectInAction;

        private void Start()
        {
            _medikalKits = FindObjectsOfType<MedicalKitModel>();
            _view = FindObjectOfType<PlayerActionView>();
            foreach (var obj in _medikalKits)
            {
                obj.onPlayerActionTriggerOn += _view.Enable;
                obj.onPlayerActionTriggerOff += _view.Disable;
            }
        }

        public override void PlayerActionStart()
        {
            foreach (var obj in _medikalKits)
            {
                if (obj.IsContact)
                {
                    obj.PlayerActionStart();
                    _objectInAction = obj;
                    _objectInAction.onPlayerActionTriggerOn -= _view.Enable;
                    _objectInAction.onPlayerActionTriggerOff -= _view.Disable;
                }
            }
        }

        public void SubscribeEvent(PlayerModel subscriber)
        {
            foreach (var obj in _medikalKits)
            {
                obj.HealthRecovery += subscriber.Healing;
            }
        }

        public void UnsubscribeEvent(PlayerModel subscriber)
        {
            foreach (var obj in _medikalKits)
            {
                obj.HealthRecovery -= subscriber.Healing;
            }
        }
    }
}
