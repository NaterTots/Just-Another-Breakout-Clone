using UnityEngine;
using System.Collections;

public class TitleScreenCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPlay()
    {
        Resolver.Instance.GetController<StateEngine>().ChangeGameState(StateEngine.States.Playing);
    }

    public void OnSettings()
    {
        Resolver.Instance.GetController<StateEngine>().ChangeGameState(StateEngine.States.Settings);
    }

    public void OnCredits()
    {
        Resolver.Instance.GetController<StateEngine>().ChangeGameState(StateEngine.States.Credits);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
