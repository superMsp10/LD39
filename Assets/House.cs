using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{

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
    }
}
