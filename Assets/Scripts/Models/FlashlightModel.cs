using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class FlashlightModel : BaseObjectScene
    {
        private Light _light;

        [SerializeField] [Tooltip("battery discharge time in seconds")] private int _battery;

        private int _currentBattery;

        public float BatteryState
        {
            get { return _currentBattery / _battery; }
        }

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
            StopCoroutine(ChargeBattery());
            if (_currentBattery >= 1)
            {
                _light.enabled = true;
                StartCoroutine(DischargeBattery());
            }
            else this.Off();
        }

        public void Off()
        {
            _light.enabled = false;
            StopCoroutine(ChargeBattery());
            if(_currentBattery <= _battery)
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

        private IEnumerator DischargeBattery()
        {
            yield return new WaitForSeconds(1);
            _currentBattery--;
        }

        private IEnumerator ChargeBattery()
        {
            if (_currentBattery < _battery)
            {
                yield return new WaitForSeconds(1);
                _currentBattery++;
            }
            else yield return null;
        }
    }
}
