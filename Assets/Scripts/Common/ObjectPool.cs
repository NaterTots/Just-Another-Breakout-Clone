using UnityEngine;
using System.Collections;

public class ObjectPool
{
    private GameObject _objectPrefab;
    public GameObject ObjectPrefab
    {
        get
        {
            return _objectPrefab;
        }
        set
        {
            _objectPrefab = value;
        }
    }

    private GameObject _parentContainer;
    public GameObject ParentContainer
    {
        set
        {
            _parentContainer = value;
        }
    }

    GameObject[] activePoolObjects;
    GameObject[] inactivePoolObjects;

    int _activeCount;
    public int ActiveCount
    {
        get
        {
            return _activeCount;
        }
    }

    int _inactiveCount;


    public void Initialize(int poolSize)
    {
        activePoolObjects = new GameObject[poolSize];
        inactivePoolObjects = new GameObject[poolSize];
    }

    public void LoadMaxInactive()
    {
        for (int i = _inactiveCount; i < inactivePoolObjects.Length; i++)
        {
            inactivePoolObjects[i] = (GameObject)MonoBehaviour.Instantiate(_objectPrefab);
            inactivePoolObjects[i].transform.parent = _parentContainer.transform;
            inactivePoolObjects[i].SetActive(false);
        }
    }

    public delegate void PrepGameObject(ref GameObject gameObject);

    public GameObject InitNewObject(PrepGameObject prep = null)
    {
        //make sure there's space for another one
        if (_activeCount < activePoolObjects.Length)
        {
            //if we have an inactive one we can use
            if (_inactiveCount > 0)
            {
                _inactiveCount--; 
                activePoolObjects[_activeCount] = inactivePoolObjects[_inactiveCount]; 
            }
            else
            {
                activePoolObjects[_activeCount] = (GameObject)MonoBehaviour.Instantiate(_objectPrefab);
                activePoolObjects[_activeCount].transform.parent = _parentContainer.transform;
            }

            activePoolObjects[_activeCount].SetActive(true);

            _activeCount++;
            if (prep != null)
            {
                prep(ref activePoolObjects[_activeCount - 1]);
            }

            return activePoolObjects[_activeCount - 1];
        }

        Debug.LogError("Pool is full!");
        return null;
    }

    public int UpdateActiveList()
    {
        int amountMoved = 0;
        for (int i = 0; i < _activeCount; i++)
        {
            if (activePoolObjects[i].activeSelf == false)
            {
                inactivePoolObjects[_inactiveCount - 1] = activePoolObjects[i];
                _inactiveCount++;
                amountMoved++;
            }
            else
            {
                //bubble active objects down
                activePoolObjects[i - amountMoved] = activePoolObjects[i];
            }
        }

        return _activeCount;
    }
}
