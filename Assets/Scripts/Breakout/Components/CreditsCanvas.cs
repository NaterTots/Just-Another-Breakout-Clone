using UnityEngine;
using System.Collections;

public class CreditsCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMainMenu()
    {
        Resolver.Instance.GetController<StateEngine>().ChangeGameState(StateEngine.States.MainMenu);
    }
}
