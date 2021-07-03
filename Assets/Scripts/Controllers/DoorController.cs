using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{

    public class DoorController : BaseEnveronmentController
    {
        private Door[] _doors;

        private PlayerActionView _view;

        private Door _objectInAction;

        private void Start()
        {
            _doors = FindObjectsOfType<Door>();
            _view = FindObjectOfType<PlayerActionView>();
            foreach (var obj in _doors)
            {
                obj.onPlayerActionTriggerOn += _view.Enable;
                obj.onPlayerActionTriggerOff += _view.Disable;
            }

        }

        public override void PlayerActionStart()
        {
            foreach (var obj in _doors)
            {
                if (obj.IsContact)
                {
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
