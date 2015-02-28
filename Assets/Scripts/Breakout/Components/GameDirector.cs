using UnityEngine;
using System.Collections;

public class GameDirector : MonoBehaviour 
{
    public GameObject ballPrefab;
    public GameObject paddlePrefab;
    public GameObject brickMapPrefab;

    public int startingLevel = 1;

    private GameObject theBall;
    private Ball ballScript;

    private GameObject thePaddle;
    private Paddle paddleScript;

    private BrickMap brickMap;

	// Use this for initialization
    void Start()
    {
        Resolver.Instance.GetController<EventController>().Subscribe(GameEvents.LostBall, OnLostBall);

        GameObject theBrickMap = (GameObject)Instantiate(brickMapPrefab);
        brickMap = theBrickMap.GetComponent<BrickMap>();

        thePaddle = (GameObject)Instantiate(paddlePrefab);
        paddleScript = thePaddle.GetComponent<Paddle>();

        theBall = (GameObject)Instantiate(ballPrefab);
        ballScript = theBall.GetComponent<Ball>();
        ballScript.ResetBall();
        paddleScript.TakeControlOfBall(theBall);

        Resolver.Instance.GetController<LevelManager>().GoToSpecificLevel(startingLevel);
    }

    void OnDestroy()
    {
        Resolver.Instance.GetController<EventController>().UnSubscribe(GameEvents.LostBall, OnLostBall);
    }

    public void OnLostBall(IEventArgs args)
    {
        int lives = Resolver.Instance.GetController<GameStats>().Lives - 1;
        Resolver.Instance.GetController<GameStats>().Lives = lives;

        if (lives <= 0)
        {
            Resolver.Instance.GetController<StateEngine>().ChangeGameState(StateEngine.States.GameOver);
        }

        ballScript.ResetBall();
    }
}
