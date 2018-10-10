using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{

    public class DoorController : BaseEnveronmentController
    {
        private Door[] _doors;

        private DoorView _view;

        private Door _objectInAction;

        private void Start()
        {
            _doors = FindObjectsOfType<Door>();
            _view = FindObjectOfType<DoorView>();
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
    }
}
