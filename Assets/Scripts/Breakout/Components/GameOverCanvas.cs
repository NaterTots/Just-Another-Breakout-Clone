using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int score = Resolver.Instance.GetController<GameStats>().Score;

        transform.FindChild("Stats").GetComponent<Text>().text =
                "Final Score: \t" + score.ToString() + System.Environment.NewLine +
                "Level Reached: \t" + 12.ToString() + System.Environment.NewLine +
                "Bricks Destroyed: \t" + 22.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMainMenu()
    {
        Resolver.Instance.GetController<StateEngine>().ChangeGameState(StateEngine.States.MainMenu);
    }
}
