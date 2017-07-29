using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

    public GameManager thisM;
    public Slider powerSlider;

    float _powerLevel = 10;
    public float powerLevel
    {
        get
        {
            return _powerLevel;
        }
        set
        {
            _powerLevel = value;
            powerSlider.value = value;
        }
    }

    void Start()
    {
        thisM = GameManager.thisM;
        thisM.currLvl = this;
        powerSlider.maxValue = _powerLevel;
        powerSlider.value = _powerLevel;

    }



}
