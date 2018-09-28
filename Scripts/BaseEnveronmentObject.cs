using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FPS
{
    public abstract class BaseEnveronmentObject : BaseObjectScene
    {
        [SerializeField]
        protected GameObject Player;

        protected Collider _playerCollider;

        protected Camera _camera;

        protected Transform _playerTransform;

        public delegate void UIMessageForPlayer();

        [SerializeField]
        protected float offsetY = 0.5f;

        [SerializeField]
        protected float offsetZ = 0.5f;

        public bool IsContact { get; private set; }

        protected virtual void OnCollisionEnter(Collision other) 
        {
            if (other.gameObject.tag.Equals(Player.tag))
            {
                IsContact = true;
                onPlayerActionTriggerOn();
            }
        }

        protected virtual void OnCollisionExit(Collision other)
        {
            if (other.gameObject.tag.Equals(Player.tag))
            {
                IsContact = false;
                onPlayerActionTriggerOff();
            }
        }

        protected override void Awake()
        {
            base.Awake();
            _playerCollider = Player.GetComponent<Collider>();
            _camera = Camera.main;
            IsContact = false;
        }

        public event UIMessageForPlayer onPlayerActionTriggerOn;

        public event UIMessageForPlayer onPlayerActionTriggerOff;

        public abstract void PlayerActionStart();
        public abstract void PlayerActionStop();
    }
}

