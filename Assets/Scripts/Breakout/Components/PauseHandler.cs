using UnityEngine;
using System.Collections;

public class PauseHandler : MonoBehaviour
{
    public GameObject pausePrefab;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Instantiate(pausePrefab);
        }
    }
}
