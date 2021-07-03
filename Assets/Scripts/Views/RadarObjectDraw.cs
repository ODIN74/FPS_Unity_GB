using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
    public class RadarObjectDraw : BaseObjectScene
    {
        [SerializeField]
        private Image drawbleImage;

        [SerializeField]
        [Range(2f,8f)]
        private float offsetY = 2f;

        private bool objectInstaniate = false;

        private void Start()
        {
            if(Mathf.Abs(PlayerModel.LocalPlayer.transform.position.y - transform.position.y) < offsetY && !objectInstaniate)
            {
                RadarMap.RegisterRadarObject(gameObject, drawbleImage);
                objectInstaniate = true;
            }

        }

        private void Update()
        {
            if (Mathf.Abs(PlayerModel.LocalPlayer.transform.position.y - transform.position.y) > offsetY && objectInstaniate)
            {
                RadarMap.RemoveRadarObject(gameObject);
                objectInstaniate = false;
            }
            if (Mathf.Abs(PlayerModel.LocalPlayer.transform.position.y - transform.position.y) < offsetY && !objectInstaniate)
            {
                RadarMap.RegisterRadarObject(gameObject, drawbleImage);
                objectInstaniate = true;
            }
        }

        private void OnDestroy()
        {
            RadarMap.RemoveRadarObject(gameObject);
        }
    }
}
