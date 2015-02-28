using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
    public float speed = 4.0f;
    public float maxSpeed = 10.0f;
    public Sprite[] possibleSprites;

    private AudioSource bounce;

	// Use this for initialization
	void Start () 
    {
        bounce = GetComponent<AudioSource>();
        ResetBall();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ResetBall()
    {
        GetComponent<SpriteRenderer>().sprite = possibleSprites[Random.Range(0, possibleSprites.Length)];

        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.Sleep();
    }

    public void LaunchBall()
    {
        rigidbody2D.WakeUp();

        Vector2 launchDirection = (Vector2.up + Vector2.right * (Random.Range(0, 2) > 0 ? 1 : -1)).normalized;
        rigidbody2D.velocity = launchDirection * speed;
    }
}
