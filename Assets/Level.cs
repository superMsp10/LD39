﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

    public GameManager thisM;
    public Slider powerSlider;
    public Text moneyText;

    public House[] houses;

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


    float _money = 10;
    public float moneyPerPackage = 1;

    public float money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
            moneyText.text = value.ToString();
        }
    }

    void Start()
    {
        thisM = GameManager.thisM;
        thisM.currLvl = this;
        powerSlider.maxValue = _powerLevel;
        powerSlider.value = _powerLevel;
        moneyText.text = _money.ToString();

        //houses = FindObjectsOfType<House>();
    }


}
