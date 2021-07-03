using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FPS
{
    public abstract class BaseEnveronmentObject : BaseObjectScene
    {
        //[SerializeField]
        //protected GameObject Player;

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
            if (other.gameObject.tag.Equals(PlayerModel.LocalPlayer.tag))
            {
                IsContact = true;
                if(onPlayerActionTriggerOn != null)
                onPlayerActionTriggerOn();
            }
        }

        protected virtual void OnCollisionExit(Collision other)
        {
            if (other.gameObject.tag.Equals(PlayerModel.LocalPlayer.tag))
            {
                IsContact = false;
                if (onPlayerActionTriggerOff != null)
                onPlayerActionTriggerOff();
            }
        }

        protected override void Awake()
        {
            base.Awake();
            _camera = Camera.main;
            IsContact = false;
        }

        protected void Start()
        {
            _playerCollider = PlayerModel.LocalPlayer.GetComponent<Collider>();
        }

        public event UIMessageForPlayer onPlayerActionTriggerOn;

        public event UIMessageForPlayer onPlayerActionTriggerOff;

        public virtual void PlayerActionStart()
        {
            if (onPlayerActionTriggerOff != null)
                onPlayerActionTriggerOff.Invoke();
        }

        public abstract void PlayerActionStop();
    }
}

