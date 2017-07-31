using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager thisM;
    public int levelNum = -1;
    public string[] levelScenes;
    public Level currLvl;
    public int loseComplaintNum = 5;
    public int totalComplaints, totalOrders, totalDeliveries, totalPower;

    // Use this for initialization
    void Awake()
    {
        if (thisM == null)
        {
            thisM = this;
            //DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F5))
        {
            restartLevel();
        }
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(levelScenes[levelNum]);
        Debug.Log("Restarted Level");

    }

    public void nextLevel()
    {
        SceneManager.LoadScene(levelScenes[1]);
    }

    public void changeLevel(Level newLvl)
    {
        currLvl = newLvl;

    }

}
