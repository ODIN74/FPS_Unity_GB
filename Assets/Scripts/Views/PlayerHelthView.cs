using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
    public class PlayerHelthView : MonoBehaviour
    {
        private PlayerModel _pModel;

        private Slider _slider;

        private void Awake()
        {
            _pModel = FindObjectOfType<PlayerModel>();
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
            _slider.value = _pModel.CurrentHelthForView;
        }

        private void Update()
        {           
            _slider.value = _pModel.CurrentHelthForView;
        }
    }
}
