using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class FlashlightController : BaseController
    {
        private FlashlightModel _model;

        private FlashlightView _view;

        private FlashlightViewUIIndicator _indicator;

        private void Awake()
        {
            _model = FindObjectOfType<FlashlightModel>();
            _view = FindObjectOfType<FlashlightView>();
            _indicator = FindObjectOfType<FlashlightViewUIIndicator>();
            Off();
        }

        private void FixedUpdate()
        {
            if (_indicator != null)
                _indicator.SetBatteryState(_model.BatteryState());
        }

        public override void Off()
        {
            base.Off();
            _model.Off();
            _view.Off();
        }

        public override void On()
        {
            base.On();
            _model.On();
            if (_model.IsOn) _view.On();
            _model.onBatteryDischarge += _view.Off;
        }

        public void Switch()
        {
            if (IsEnabled)
                Off();
            else
                On();
        }
    }
}
