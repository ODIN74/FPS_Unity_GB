using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class FlashlightModel : BaseObjectScene
    {
        private Light _light;

        [SerializeField] [Tooltip("battery discharge time in seconds")] private float _battery = 30.0f;

        private float _currentBattery;

        public bool IsOn
        {
            get
            {
                if (!_light) return false;
                return _light.enabled;
            }
        }

        protected override void Awake()
        {
            _light = GetComponent<Light>();
            _currentBattery = _battery;
        }

        public void On()
        {
            StopAllCoroutines();
            if(_currentBattery >= 1)
            {
                _light.enabled = true;
                StartCoroutine(DischargeBattery());
            }
        }

        public void Off()
        {
            _light.enabled = false;
            StopAllCoroutines();
            if (_currentBattery < _battery)
            {
                StartCoroutine(ChargeBattery());
            }
        }

        public void Switch()
        {
            if (IsOn)
                Off();
            else
                On();
        }

        public event Action onBatteryDischarge;

        public float BatteryState()
        {        
            return _currentBattery / _battery;
        }

        private IEnumerator DischargeBattery()
        {
            do
            {
                yield return new WaitForSeconds(1);
                _currentBattery--;
            }
            while (_currentBattery > 0);
            this.Off();
            onBatteryDischarge();
        }

        private IEnumerator ChargeBattery()
        {
                while (_currentBattery < _battery)
            {
                yield return new WaitForSeconds(1);
                _currentBattery++;
            }
        }
    }
}
