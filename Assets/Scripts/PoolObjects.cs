using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{

    public class PoolObjects : MonoBehaviour
    { 
        public static PoolObjects Instance { get; private set; }

        [SerializeField]
        private GameObject[] _objects;

        private Dictionary<string, Queue<IPoolable>> _objectsDict = new Dictionary<string, Queue<IPoolable>>();
        private Dictionary<string, int> _objectsTypeDict= new Dictionary<string, int>();

        private void Awake()
        {
            if (Instance)
                DestroyImmediate(this);
            else
                Instance = this;
        }

        private void Start()
        {
            foreach (var obj in _objects)
            {
                IPoolable poolObj = obj.GetComponent<IPoolable>();
                if(poolObj == null)
                {
                    continue;
                }

                _objectsTypeDict.Add(poolObj.PoolID, Array.IndexOf(_objects, obj));
                Queue<IPoolable> queue = new Queue<IPoolable>();

                for (int i = 0; i < poolObj.countOjects; i++)
                {
                    GameObject go = Instantiate(obj);
                    go.SetActive(false);
                    queue.Enqueue(go.GetComponent<IPoolable>());
                }
                _objectsDict.Add(poolObj.PoolID, queue);
            }

        }

        public IPoolable GetObject(string poolID)
        {
            if (string.IsNullOrEmpty(poolID))
            {
                return null;
            } 

            if (!_objectsDict.ContainsKey(poolID))
            {
                return null;
            }

            IPoolable p;

            try
            {
                p = _objectsDict[poolID].Dequeue();
            }
            catch (InvalidOperationException e)
            {
                Debug.Log(e);
                GameObject go = Instantiate(_objects[_objectsTypeDict[poolID]]);
                go.SetActive(false);
                p = go.GetComponent<IPoolable>();
            }
            _objectsDict[poolID].Enqueue(p);
            return p;
        }
    }
}
