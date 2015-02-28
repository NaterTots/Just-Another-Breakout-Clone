using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour 
{
    public Material[] materials;
    public Shader blackAndWhite;

    private Shader[] shaders;

	// Use this for initialization
	void Start () 
    {
        Time.timeScale = 0.0f;

        //this is used to cache the shaders for the materials
        shaders = new Shader[materials.Length];
        for (int i = 0; i < materials.Length; i++)
        {
            shaders[i] = materials[i].shader;
            materials[i].shader = blackAndWhite;
        }
    }
	
    void OnDestroy()
    {
        Time.timeScale = 1.0f;
    }

    public void OnResume()
    {
        Debug.Log("Resume game");

        RestoreMaterials();

        DestroyObject(this.gameObject);
    }

    public void OnQuit()
    {
        Debug.Log("Quit game");

        RestoreMaterials();

        Application.Quit();
    }

    private void RestoreMaterials()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].shader = shaders[i];
        }
    }
}
