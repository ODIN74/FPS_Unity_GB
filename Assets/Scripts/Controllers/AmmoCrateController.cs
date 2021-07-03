using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class AmmoCrateController : BaseEnveronmentController
    {
        private AmmoCrateModel[] _crates;

        private PlayerActionView _view;

        private AmmoCrateModel _objectInAction;

        private void Start()
        {
            _crates = FindObjectsOfType<AmmoCrateModel>();
            _view = FindObjectOfType<PlayerActionView>();
            foreach (var obj in _crates)
            {
                obj.onPlayerActionTriggerOn += _view.Enable;
                obj.onPlayerActionTriggerOff += _view.Disable;
            }
        }

        public override void PlayerActionStart()
        {
            foreach (var obj in _crates)
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

        public void SubscribeEvent(BaseWeapon subscriber)
        {
            foreach(var obj in _crates)
            {
                obj.BulletsRecovery += subscriber.BulletRecovery;
            }
        }

        public void UnsubscribeEvent(BaseWeapon subscriber)
        {
            foreach (var obj in _crates)
            {
                obj.BulletsRecovery -= subscriber.BulletRecovery;
            }
        }
    }
}
