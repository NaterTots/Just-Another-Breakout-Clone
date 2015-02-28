using UnityEngine;
using System.Collections;

//most of this class was ripped from the Kongregate forums
public class KongregateSubmitter : MonoBehaviour, IController
{
    /// <summary>
    /// Are we connected to Kongregate's API?
    /// </summary>
    public bool Connected { get; private set; }
    /// <summary>
    /// The user's UserID.
    /// </summary>
    public int UserId { get; private set; }
    /// <summary>
    /// The user's username.
    /// </summary>
    public string UserName { get; private set; }
    /// <summary>
    /// The game's authentication token.
    /// </summary>
    public string GameAuthToken { get; private set; }

	// Use this for initialization
	void Start () 
    {
        if (!Connected)
        {
            Application.ExternalEval(
                "if(typeof(kongregateUnitySupport) != 'undefined'){" +
                " kongregateUnitySupport.initAPI('KongregateSubmitter', 'OnKongregateAPILoaded');" +
                "};"
                );
        }
	}

    public void Submit(string statisticName, int value)
    {
        if (Connected)
        {
            Application.ExternalCall("kongregate.stats.submit", statisticName, value);
        }
        else
        {
            Debug.LogWarning("Attempting to submit a statistic without being connected to Kongregate's API.");
        }
    }

    void OnKongregateAPILoaded(string userInfoString)
    {
        // We now know we're on Kongregate
        Connected = true;

        string[] parameters = userInfoString.Split('|');
        UserId = System.Convert.ToInt32(parameters[0]);
        UserName = parameters[1];
        GameAuthToken = parameters[2];
    }

    public void Cleanup()
    {
       //there's no need to disconnect from the kongregate API
    }
}
