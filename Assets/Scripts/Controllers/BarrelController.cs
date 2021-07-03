using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class BarrelController : BaseEnveronmentController
    {
        private BarrelModel[] _model;
        private PlayerActionView _view;

        private BarrelModel _objectInAction;

        private void Start()
        {
            _model = FindObjectsOfType<BarrelModel>();
            _view = FindObjectOfType<PlayerActionView>();
            foreach (var obj in _model)
            {
                obj.onPlayerActionTriggerOn += _view.Enable;
                obj.onPlayerActionTriggerOff += _view.Disable;
            }
        }

        public override void PlayerActionStart()
        {
            foreach(var obj in _model)
            {
                if (obj.IsContact)
                {
                    obj.PlayerActionStart();
                    _objectInAction = obj;
                }
            }
        }

        public override void PlayerActionStop()
        {
            if(_objectInAction)
                _objectInAction.PlayerActionStop();
        }

        private void OnDestroy()
        {
            if(_objectInAction && _view)
            {
                _objectInAction.onPlayerActionTriggerOn -= _view.Enable;
                _objectInAction.onPlayerActionTriggerOff -= _view.Disable;
            }
        }
    }
}
