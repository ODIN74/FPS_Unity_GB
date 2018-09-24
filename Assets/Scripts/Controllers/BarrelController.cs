using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class BarrelController : BaseEnveronmentController
    {
        private BarrelModel[] _model;
        private BarrelView _view;

        private void Start()
        {
            _model = FindObjectsOfType<BarrelModel>();
            _view = FindObjectOfType<BarrelView>();
            foreach (var obj in _model)
            {
                obj.onPlayerActionTriggerOn += _view.Enable;
                obj.onPlayerActionTriggerOff += _view.Disable;
            }

        }

        public override void PlayerAction()
        {
            foreach(var obj in _model)
            {
                if (obj.IsContact)
                    obj.PlayerAction();
            }
        }
    }
}
