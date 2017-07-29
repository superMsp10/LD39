using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public GameManager thisM;

	void Start () {
        thisM = GameManager.thisM;
        thisM.currLvl = this;
	}

   

}
