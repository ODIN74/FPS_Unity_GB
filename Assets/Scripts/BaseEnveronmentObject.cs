using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FPS
{
    public abstract class BaseEnveronmentObject : BaseObjectScene
    {
        [SerializeField] protected GameObject Player;

        protected Collider _playerCollider;

        protected Transform _playerTransform;

        public delegate void UIMessageForPlayer();

        protected virtual void OnCollisionEnter(Collision other) 
        {
            onPlayerActionTriggerOn();
        }

        protected virtual void OnCollisionExit(Collision other)
        {
                onPlayerActionTriggerOff();
        }

        protected override void Awake()
        {
            base.Awake();
            _playerCollider = Player.GetComponent<Collider>();
        }

        public event UIMessageForPlayer onPlayerActionTriggerOn;

        public event UIMessageForPlayer onPlayerActionTriggerOff;

        public abstract void PlayerAction();
    }
}

