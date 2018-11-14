using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadMenu1()
    {
        SceneManager.LoadScene("Menu 1");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void LoadGame_00()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadGame_01()
    {
        SceneManager.LoadScene("Game 1");
    }

    public void LoadGame_02()
    {
        SceneManager.LoadScene("Game 2");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
