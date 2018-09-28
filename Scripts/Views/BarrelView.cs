using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
    public class BarrelView : MonoBehaviour
    {
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        public void Enable()
        {
            _canvas.enabled = true;
        }

        public void Disable()
        {
            _canvas.enabled = false;
        }
    }
}


