using UnityEngine;
using System.Collections;

public class SettingsCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnVolumeSlider(float value)
    {
        AudioListener.volume = value;
    }

    public void OnMainMenu()
    {
        Resolver.Instance.GetController<StateEngine>().ChangeGameState(StateEngine.States.MainMenu);
    }
}
