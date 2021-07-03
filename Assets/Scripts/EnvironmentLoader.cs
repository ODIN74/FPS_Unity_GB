using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;
using UnityEngine.AI;

namespace FPS
{
    public class EnvironmentLoader : MonoBehaviour
    {
        [SerializeField]
        private string _ammoCratePrefabName;

        [SerializeField]
        private string _medicalKitPrefabName;

        [Header("Number of  objects")]
        [SerializeField]
        private int _ammoCrateNumber;

        [SerializeField]
        private int _medicalKitNumber;

        [SerializeField]
        private float _levelSphereRadius;

        private float offsetY = 0.65f;

        private GameObject[] _gameObjsForLoad;

        private void Start()
        {
            var totalNumberOfObjects = _ammoCrateNumber + _medicalKitNumber;

            _gameObjsForLoad = new GameObject[totalNumberOfObjects];

            for(int i = 0; i < totalNumberOfObjects; i++)
            {
                if (i < _ammoCrateNumber)
                {
                    _gameObjsForLoad[i] = GameObject.Instantiate(Resources.Load<GameObject>(_ammoCratePrefabName));
                }
                    
                else
                {
                    _gameObjsForLoad[i] = GameObject.Instantiate(Resources.Load<GameObject>(_medicalKitPrefabName));
                }  
            }

            foreach(var obj in _gameObjsForLoad)
            {

                var tempPos = Random.insideUnitSphere * _levelSphereRadius;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(tempPos, out hit, 100f, NavMesh.AllAreas))
                    tempPos = hit.position;

                obj.transform.position = new Vector3(tempPos.x, tempPos.y + offsetY, tempPos.z);

                Vector3 curRot = obj.transform.rotation.eulerAngles;

                obj.transform.rotation = Quaternion.Euler(curRot.x, Random.Range(-90f, 90f), curRot.z);
            }
        }
    }
}
