using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class TeammateSelectorView : BaseObjectScene
    {
        private TeammateModel _model;

        private Light _selectorLight;

        protected override void Awake()
        {
            base.Awake();
            _model = GetComponentInParent<TeammateModel>();
            _selectorLight = GetComponent<Light>();

            TeammateController.OnTeammateSelected += TeammateSelected;
            _selectorLight.enabled = false;
        }

        private void TeammateSelected(TeammateModel model)
        {
            _selectorLight.enabled = _model == model;
        }

        private void OnDestroy()
        {
            TeammateController.OnTeammateSelected -= TeammateSelected;
        }
    }
}
