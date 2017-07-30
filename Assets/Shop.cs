using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public Renderer thisR;
    public Color valid, invalid;
    public int price;

    public GameObject spawnPrefab;
    public Transform spawnPos;
    public Vector3 distance;
    public int numSpawned = 1;

    public int type;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void checkValidity()
    {
        if (GameManager.thisM.currLvl.money - price >= 0)
        {
            thisR.material.color = valid;
        }
        else
        {
            thisR.material.color = invalid;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (GameManager.thisM.currLvl.money - price >= 0)
        {
            GameObject g = (GameObject)Instantiate(spawnPrefab, Vector2.zero, Quaternion.identity, spawnPos);
            g.transform.localPosition = new Vector3(distance.x * numSpawned, distance.y * numSpawned, distance.z * numSpawned);

            if (type == 0)
            {
                GameManager.thisM.currLvl.powerSources.Add(g.GetComponentInChildren<PowerSource>());
            }

            GameManager.thisM.currLvl.money -= price;
            numSpawned++;
        }
    }
}
