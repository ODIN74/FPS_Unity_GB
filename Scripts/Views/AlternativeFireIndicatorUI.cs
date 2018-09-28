using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
    public class AlternativeFireIndicatorUI : MonoBehaviour
    {
        private Slider _slider;

        void Start()
        {
            _slider = GetComponent<Slider>();

            MultiBarreledFirearms.OnAlternativeFire += ChangeIndicatorValue;
        }

        private void ChangeIndicatorValue(float energy)
        {
            if (_slider != null)
                _slider.value = energy;
        }
    }	
}
