using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public Vector3 ballHoldingPosition;

    bool holdingBall = false;
    GameObject ownedBall;

    Vector2 speed = new Vector2(5.0f, 0.0f);

	// Use this for initialization
	void Start () 
    {
	}

	// Update is called once per frame
	void Update() 
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            rigidbody2D.MovePosition(rigidbody2D.position + speed * Time.deltaTime);
            //transform.Translate(new Vector2(0.1f, 0.0f));
        }
        else if (horizontal < 0)
        {
            rigidbody2D.MovePosition(rigidbody2D.position - speed * Time.deltaTime);
            //transform.Translate(new Vector2(-0.1f, 0.0f));
        }
        //else
        //{
        //
        //}

        if (holdingBall)
        {
            PlaceBall();

            if (Input.GetButtonDown("Jump"))
            {
                ownedBall.GetComponent<Rigidbody2D>().isKinematic = false;
                LaunchBall();
            }
        }
	}

    public void TakeControlOfBall(GameObject b)
    {
        ownedBall = b;
        ownedBall.GetComponent<Rigidbody2D>().isKinematic = true;

        PlaceBall();

        holdingBall = true;
    }

    void LaunchBall()
    {
        holdingBall = false;
        ownedBall.GetComponent<Ball>().LaunchBall();
    }

    private void PlaceBall()
    {
        ownedBall.transform.position = new Vector3(transform.position.x + ballHoldingPosition.x,
                                            transform.position.y + ballHoldingPosition.y,
                                            transform.position.z + ballHoldingPosition.z);
    }
}
