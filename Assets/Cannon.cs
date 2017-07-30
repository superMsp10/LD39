using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class Cannon : MonoBehaviour
{
    public GameObject cannonCamera;
    public GameObject cannonBarrel;
    public GameObject powerError;


    public GameObject cannonCanvas;
    public SimpleMouseRotator mouseFollow;
    bool operating = false;
    public GameObject player;
    public Transform playerExit;

    float timeStarted;
    public float maximumHeldTime;
    public float minimumHeldTime = 0.5f;
    public float defaultHeldTime;
    bool startedHold = false;

    public float powerConsumption = 1;

    public float launchForce;
    public Object launchObject;

    bool enoughPower = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            enterCannon();
        }
    }

    void Update()
    {
        if (operating)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                exitCannon();
            }

            if (enoughPower)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    startHold();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    endHold();
                }
            }
        }
    }

    void startHold()
    {
        //    ren.material.color = Color.Lerp(normal, highlighted, (Time.time - timeStarted) / maximumHeldTime);
        timeStarted = Time.time;

    }

    void endHold()
    {
        //Apply Force
        float force = 0f;
        float heldTime = Time.time - timeStarted;

        if (heldTime <= minimumHeldTime)
            return;

        if (heldTime > maximumHeldTime)
            force = launchForce;
        else
            force = ((heldTime + defaultHeldTime) / maximumHeldTime) * launchForce;

        GameObject g = (GameObject)Instantiate(launchObject, cannonCamera.transform.position, Quaternion.identity, null);
        g.GetComponent<Rigidbody>().AddForce(cannonCamera.transform.forward * force);

        GameManager.thisM.currLvl.powerLevel -= powerConsumption;
        powerCheck();
    }

    void powerCheck()
    {
        if (GameManager.thisM.currLvl.powerLevel < powerConsumption)
        {
            powerError.SetActive(true);
            enoughPower = false;
        }
        else
        {
            powerError.SetActive(false);
            enoughPower = true;
        }
    }

    void exitCannon()
    {
        mouseFollow.enabled = false;
        cannonCamera.SetActive(false);
        cannonBarrel.SetActive(true);

        cannonCanvas.SetActive(false);

        player.transform.position = playerExit.position;
        player.SetActive(true);
        operating = false;
    }

    void enterCannon()
    {
        mouseFollow.enabled = true;
        cannonCamera.SetActive(true);
        cannonBarrel.SetActive(false);

        cannonCanvas.SetActive(true);

        player.SetActive(false);
        operating = true;

        powerCheck();
    }


}
