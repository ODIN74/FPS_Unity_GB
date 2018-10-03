using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public interface ISBBulletPack
    {
        [SerializeField]
        int RecoverableBullets { get; }

        void Recovery(int RecoverableBullets);
    }
}


