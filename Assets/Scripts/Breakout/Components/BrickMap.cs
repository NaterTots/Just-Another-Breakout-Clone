using UnityEngine;
using System.Collections;

public class BrickMap : MonoBehaviour 
{
    public GameObject brick;

    float brickWidth;
    float brickHeight;

	// Use this for initialization
	void Awake () 
    {
        Resolver.Instance.GetController<EventController>().Subscribe(GameEvents.OnLevelStart, OnLevelStart);

        brickWidth = brick.renderer.bounds.size.x;
        brickHeight = brick.renderer.bounds.size.y;
        Debug.Log("brickWidth: " + brickWidth);
        Debug.Log("brickHeight: " + brickHeight);
	}

    void OnDestroy()
    {
        Resolver.Instance.GetController<EventController>().UnSubscribe(GameEvents.OnLevelStart, OnLevelStart);
    }

	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnLevelStart(IEventArgs args)
    {
        LoadFromLevel(Resolver.Instance.GetController<LevelManager>().CurrentLevel);
    }

    void LoadFromLevel(Level level)
    {
        Debug.Log("Level Num: " + level.LevelNum);

        for(int x = 0; x < Level.Height; x++)
        {
            for (int y = 0; y < Level.Width; y++)
			{
                Debug.Log("Level " + x.ToString() + ", " + y.ToString() + ": " + level.BrickArray[x, y].ToString());

                if (level.BrickArray[x,y] == Brick.BrickType.Normal)
                {
                    GameObject newBrick = (GameObject)Instantiate(brick);
                    newBrick.transform.parent = this.transform;
                    newBrick.transform.localPosition = new Vector2(y * brickWidth, -x * brickHeight);
                    
                }
                
			}
        }
    }
}
