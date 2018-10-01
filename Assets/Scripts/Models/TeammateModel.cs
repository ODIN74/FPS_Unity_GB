using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace FPS
{
    public class TeammateModel : BaseObjectScene
    {
        private NavMeshAgent _agent;
        private ThirdPersonCharacter _teammate;

        private Vector3 _currentPosition;
        private bool _followPlayer;

        [SerializeField]
        private float maxDistance = 2.0f;

        private Queue<Vector3> positionQueue = new Queue<Vector3>();

        private Transform _playerTransform;

        private void Start()
        {
            _currentPosition = transform.position;
            _agent = GetComponentInChildren<NavMeshAgent>();
            _teammate = GetComponent<ThirdPersonCharacter>();

            _agent.updatePosition = false;
            _agent.updateRotation = true;
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            if(_followPlayer && _playerTransform != null)
            {
                _agent.SetDestination(_playerTransform.position);
            }

            if (_agent.remainingDistance > _agent.stoppingDistance)
            {
                _teammate.Move(_agent.desiredVelocity, false, false);
            }
            else
            {
                _teammate.Move(Vector3.zero, false, false);
            }
        }

        public void SwitchFollow()
        {
            _followPlayer = !_followPlayer;
        }

        public void SetDesination(Vector3 position)
        {
            positionQueue.Enqueue(position);

            Debug.Log(positionQueue.Count);

            if (_agent.remainingDistance < 0.5f)
            {
                var nextPosition = positionQueue.Dequeue();
                NavMeshHit hit;
                if (NavMesh.SamplePosition(nextPosition, out hit, maxDistance, -1))
                {
                    SwitchFollow();
                    _agent.SetDestination(hit.position);
                    Debug.Log(positionQueue.Count);
                }
                else
                {
                    Debug.Log("Unreachable position");
                }
            }
        }
    }
}
