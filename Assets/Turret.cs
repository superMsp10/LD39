using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Cannon
{
    public float cooldowm;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Step", 5f, cooldowm);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Step()
    {
        if (! (GameManager.thisM.currLvl.powerLevel - powerConsumption > 0))
        {
            return;
        }

        List<House> targets = new List<House>();
        foreach (var item in GameManager.thisM.currLvl.houses)
        {
            if (item.ordered > 0)
            {
                targets.Add(item);
            }
        }

        if (targets.Count > 0)
        {
            Vector3 target = targets[Random.Range(0, targets.Count)].transform.position;
            target.y += Vector3.Distance(transform.position, target)/5 + Random.Range(-20, 20);
            cannonBarrel.transform.LookAt(target);
            //StartCoroutine(LookAt(targets[Random.Range(0, targets.Count)].transform.position));
            fire(target);
        }
    }

    public void fire( Vector3 other)
    {
        GameObject g = (GameObject)Instantiate(launchObject, cannonCamera.transform.position, Quaternion.identity, null);
        g.GetComponent<Rigidbody>().AddForce(cannonCamera.transform.forward * launchForce * Mathf.Pow( Vector3.Distance(transform.position, other)/400, 1.5f));

        GameManager.thisM.currLvl.powerLevel -= powerConsumption;
    }

    //IEnumerator LookAt(Vector3 target)
    //{
    //    Debug.Log("lOOKAT");

    //    Vector3 dir = target - transform.position;
    //    Quaternion rot = Quaternion.LookRotation(dir);

    //    while (false)
    //    {
    //        turretHead.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
    //        yield return new WaitForSeconds(0.01f);
    //    }


    //}

}
