using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public interface IMedicalKit
    {
        [SerializeField]
        int RecoverableAmount { get; }

        void RecoveryHelth(int RecoverableAmount);
    }
}


