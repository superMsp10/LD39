using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject exclamationMark;
    public Material exclamation_black;
    public Material exclamation_red;
   public int ordered = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("package"))
        {
            packageReceived();
            collision.rigidbody.isKinematic = true;
            collision.collider.enabled = false;
        }
    }

    public void packageReceived()
    {
        GameManager.thisM.currLvl.money += GameManager.thisM.currLvl.moneyPerPackage;
        GameManager.thisM.totalDeliveries++;
        exclamationMark.SetActive(false);
        ordered = 0;
    }

    public void Order()
    {
        ordered ++;
        GameManager.thisM.totalOrders++;
        exclamationMark.SetActive(true);

        if(ordered >= GameManager.thisM.currLvl.complainOrderNum)
        {
            exclamationMark.GetComponent<Renderer>().material = exclamation_red;
            GameManager.thisM.totalComplaints++;
        }
        else
        {
            exclamationMark.GetComponent<Renderer>().material = exclamation_black;
        }
    }
}
