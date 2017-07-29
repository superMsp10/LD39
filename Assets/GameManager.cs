using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager thisM;
    public int levelNum = -1;
    public string[] levelScenes;
    public string startScene, uiScene, endScene;
    public Level currLvl;

	// Use this for initialization
	void Awake () {
		if (thisM == null)
        {
            thisM = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
	}

    public void restartLevel()
    {
        SceneManager.LoadScene(levelScenes[levelNum]);
        Debug.Log("Restarted Level");

    }

    public void nextLevel()
    {
        if (levelNum == levelScenes.Length)
        {
            endCutscene();
        }
        else
        {
            SceneManager.LoadScene(levelNum++);
        }
    }

    public void startCutscene()
    {
        SceneManager.LoadScene(startScene);
    }

    public void loadUiScene()
    {
        SceneManager.LoadScene(uiScene);
    }

    public void endCutscene()
    {
        SceneManager.LoadScene(endScene);
    }
    public void changeLevel(Level newLvl)
    {
        currLvl = newLvl;

    }

}
