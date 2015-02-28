using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour, IController
{
    public TextAsset levelData;

    private Dictionary<int, Level> levels = new Dictionary<int, Level>();

    private int _currentLevel;
    public int CurrentLevelNum
    {
        get
        {
            return _currentLevel;
        }
    }

    public Level CurrentLevel
    {
        get
        {
            return levels[_currentLevel];
        }
    }

    private enum LevelManagerStateChanges
    {
        OnLevelStart,
        OnLevelEnd
    };

	// Use this for initialization
    void Start()
    {
        //this is unique
        //this object only needs to be scoped for the life of the scene with which it presides, but
        //for ease of access we put it in the Resolver
        Resolver.Instance.AddController(this);

        LevelLoader loader = new LevelLoader();
        loader.LoadData(levelData, this);
    }

	// Update is called once per frame
	void Update () 
    {
        
	}

    void OnDestroy()
    {
        Resolver.Instance.RemoveController(this);
    }

    public void GoToNextLevel()
    {
        Resolver.Instance.GetController<EventController>().FireEvent(GameEvents.OnLevelEnd, null);
        _currentLevel++;
        Resolver.Instance.GetController<EventController>().FireEvent(GameEvents.OnLevelStart, new LevelStartEventArgs(CurrentLevel));
    }

    public void GoToSpecificLevel(int n)
    {
        _currentLevel = n;
        Resolver.Instance.GetController<EventController>().FireEvent(GameEvents.OnLevelStart, new LevelStartEventArgs(CurrentLevel));
    }

    public void AddLevel(int levelnum, Level level)
    {
        if (levels.ContainsKey(levelnum))
        {
            Debug.LogError("Attempting to add level that's already been added");
        }
        else
        {
            Debug.Log("Added Level:");
            for (int i = 0; i < Level.Height; i++)
            {
                string s = "";
                for (int j = 0; j < Level.Width; j++)
                {
                    s += level[i, j].ToString() + ", ";
                }
                Debug.Log(s);
            }
            levels[levelnum] = level;
        }
    }

    public void Cleanup()
    {
    
    }
}
