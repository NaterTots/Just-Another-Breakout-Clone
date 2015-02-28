using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour, IController
{
    //TODO: this is a ton of boilerplate code for a single stat.  this needs to be refactored
    private int _score;
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            if (OnScoreChange != null)
            {
                OnScoreChange(_score);
            }
        }
    }
    public delegate void ScoreChange(int score);
    public ScoreChange OnScoreChange;


    public int StartingLives;

    private int _lives;
    public int Lives
    {
        get
        {
            return _lives;
        }
        set
        {
            _lives = value;
            if (OnLivesChange != null)
            {
                OnLivesChange(_lives);
            }
        }
    }
    public delegate void LivesChange(int lives);
    public LivesChange OnLivesChange;

    private int _brokenBricks;
    public int BrokenBricks
    {
        get
        {
            return _brokenBricks;
        }
        set
        {
            _brokenBricks = value;
            if (OnBrokenBricksChange != null)
            {
                OnBrokenBricksChange(_brokenBricks);
            }
        }
    }
    public delegate void BrokenBricksChange(int brokenBricks);
    public BrokenBricksChange OnBrokenBricksChange;

    private int _level;
    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
            if (OnLevelChange != null)
            {
                OnLevelChange(_level);
            }
        }
    }
    public delegate void LevelChange(int level);
    public LevelChange OnLevelChange;

    // Use this for initialization
    void Start()
    {
        Resolver.Instance.GetController<StateEngine>().SubscribeToStateLoad(StateEngine.States.Playing, ResetStats);
    }

    public void ResetStats(string startState, string endState)
    {
        Lives = StartingLives;
        Score = 0;
    }

    public void Cleanup()
    {
        
    }
}