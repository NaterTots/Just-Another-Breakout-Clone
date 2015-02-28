using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameCanvas : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        Resolver.Instance.GetController<GameStats>().OnLevelChange += OnLevelChange;
        Resolver.Instance.GetController<GameStats>().OnLivesChange += OnLivesChange;
        Resolver.Instance.GetController<GameStats>().OnScoreChange += OnScoreChange;
	}

    void OnDestroy()
    {
        Resolver.Instance.GetController<GameStats>().OnLivesChange -= OnLevelChange;
        Resolver.Instance.GetController<GameStats>().OnLivesChange -= OnLivesChange;
        Resolver.Instance.GetController<GameStats>().OnScoreChange -= OnScoreChange;
    }

    void OnLevelChange(int level)
    {
        transform.FindChild("Level").GetComponent<Text>().text = level.ToString();
    }

    void OnScoreChange(int score)
    {
        transform.FindChild("Score").GetComponent<Text>().text = score.ToString();
    }

    void OnLivesChange(int lives)
    {
        transform.FindChild("Lives").GetComponent<Text>().text = lives.ToString();
    }
}
