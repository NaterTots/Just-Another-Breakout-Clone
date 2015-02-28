using UnityEngine;
using System.Collections;

public class BrickMap : MonoBehaviour 
{
    public GameObject brick;

    private BrickPool _brickPool;

    float brickWidth;
    float brickHeight;

	// Use this for initialization
	void Awake () 
    {
        Resolver.Instance.GetController<EventController>().Subscribe(GameEvents.OnLevelStart, OnLevelStart);
        Resolver.Instance.GetController<EventController>().Subscribe(GameEvents.BrickDestroyed, OnBrickDestroyed);

        brickWidth = brick.renderer.bounds.size.x;
        brickHeight = brick.renderer.bounds.size.y;

        _brickPool = new BrickPool();
        _brickPool.brickFab = brick;
        _brickPool.Initialize(this.gameObject);
	}

    void OnDestroy()
    {
        Resolver.Instance.GetController<EventController>().UnSubscribe(GameEvents.OnLevelStart, OnLevelStart);
        Resolver.Instance.GetController<EventController>().UnSubscribe(GameEvents.BrickDestroyed, OnBrickDestroyed);
    }

	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnLevelStart(IEventArgs args)
    {
        LoadFromLevel(Resolver.Instance.GetController<LevelManager>().CurrentLevel);
    }

    void OnBrickDestroyed(IEventArgs args)
    {
        if (_brickPool.GetActiveCount() <= 0)
        {
            Resolver.Instance.GetController<LevelManager>().GoToNextLevel();
        }
    }

    void LoadFromLevel(Level level)
    {
        for(int x = 0; x < Level.Height; x++)
        {
            for (int y = 0; y < Level.Width; y++)
			{
                if (level.BrickArray[x,y] == Brick.BrickType.Normal)
                {
                    GameObject newBrick = (GameObject)_brickPool.InitNewBrick();
                    newBrick.transform.localPosition = new Vector2(y * brickWidth, -x * brickHeight);
                }
                
			}
        }
    }
}
