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
                    PlayerModel.LocalPlayer.GetComponent<PlayerModel>().Healing(obj.RecoverableAmount);
                    _objectInAction = obj;
                    obj.PlayerActionStart();
                }
            }
        }

        public override void PlayerActionStop()
        {
            if (_objectInAction)
            {
                _objectInAction.PlayerActionStop();
                _objectInAction.onPlayerActionTriggerOn -= _view.Enable;
                _objectInAction.onPlayerActionTriggerOff -= _view.Disable;
            }
        }
    }
}
