using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FPS
{
    public class FlashlightView : BaseObjectScene {

        public void On()
        {
            this.IsVisible = true;
        }

        public void Off()
        {
            this.IsVisible = false;
        }
    }
}
