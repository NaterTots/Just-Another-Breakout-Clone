using UnityEngine;
using System.Collections;

public class AchievementsManager : MonoBehaviour, IController 
{
	// Use this for initialization
	void Start () 
    {
        Resolver.Instance.GetController<StateEngine>().SubscribeToStateDestroy(StateEngine.States.Playing, OnGameOver);
	}

    public void OnGameOver(string startState, string endState)
    {
        GameStats gameStats = Resolver.Instance.GetController<GameStats>();

        KongregateSubmitter kongregate = Resolver.Instance.GetController<KongregateSubmitter>();

        kongregate.Submit("Score", gameStats.Score);
        kongregate.Submit("TotalBricksBroken", gameStats.BrokenBricks);
        kongregate.Submit("Level", gameStats.Level);
    }

    public void Cleanup()
    {

    }
}
