using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class BarrelController : BaseEnveronmentController
    {
        private BarrelModel _model;
        private BarrelView _view;

        private void Awake()
        {
            _model = FindObjectOfType<BarrelModel>();
            _view = FindObjectOfType<BarrelView>();
            _model.onPlayerActionTriggerOn += _view.Enable;
            _model.onPlayerActionTriggerOff += _view.Disable;
        }

        public override void PlayerAction()
        {
            _model.PlayerAction();
        }
    }
}
