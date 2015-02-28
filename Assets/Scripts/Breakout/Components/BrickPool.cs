using UnityEngine;
using System.Collections;

public class BrickPool 
{
    public int maxBrickCount = 80;
    public GameObject brickFab;

    private ObjectPool _objectPool;


    public void Initialize(GameObject parentContainer)
    {
        _objectPool = new ObjectPool();
        _objectPool.ObjectPrefab = brickFab;
        _objectPool.ParentContainer = parentContainer;
        _objectPool.Initialize(maxBrickCount);
    }

    public int GetActiveCount()
    {
        return _objectPool.UpdateActiveList();
    }

    public GameObject InitNewBrick()
    {
        return _objectPool.InitNewObject();
    }
}
