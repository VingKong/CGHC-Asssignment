using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private bool poolCanExpand = true;

    private List<GameObject> _poolObjects;
    private GameObject _poolContainer;
    
    private void Start()
    {
        _poolContainer = new GameObject("Pooler: " + objectPrefab.name);
        CreatePool();
    }

    // create one pool that will store all the object
    private void CreatePool()
    {
        _poolObjects = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            AddObjectToPool();
        }
    }

    // add the object into the pool
    private GameObject AddObjectToPool()
    {
        GameObject newObject = Instantiate(objectPrefab);
        newObject.SetActive(false);
        newObject.transform.SetParent(_poolContainer.transform);
        
        _poolObjects.Add(newObject);
        return newObject;
    }

    // get one of the object from the pool
    public GameObject GetObjectFromPool()
    {
        for (int i = 0; i < _poolObjects.Count; i++)
        {
            if (!_poolObjects[i].activeInHierarchy)
            {
                return _poolObjects[i];
            }
        }

        if (poolCanExpand)
        {
            return AddObjectToPool();
        }

        return null;
    }
}
