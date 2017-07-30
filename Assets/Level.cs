using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

    public GameManager thisM;
    public Slider powerSlider;
    public Text moneyText;

    public House[] houses;
    public Camera currCamera;

    public float maxPowerLevel = 100;
    public float _powerLevel = 10;
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

    public float OrderInterval;
    public float PowerInterval;

    public int complainOrderNum = 2;
    public int ordersAmountLevel = 1;

    public List<PowerSource> powerSources;

    void Start()
    {
        thisM = GameManager.thisM;
        thisM.currLvl = this;
        powerSlider.maxValue = _powerLevel;
        powerSlider.value = _powerLevel;
        moneyText.text = _money.ToString();
        InvokeRepeating("randomOrder", 5f, OrderInterval);
        InvokeRepeating("powerInput", 5f, PowerInterval);

        //houses = FindObjectsOfType<House>();
        //powerSources = new List<PowerSource>(FindObjectsOfType<PowerSource>());
    }

    public void randomOrder()
    {

        Debug.Log("Order Step: " + ordersAmountLevel);
        for (int i = 0; i < ordersAmountLevel; i++)
        {
            Debug.Log("Order Level: " + i);

            if (Random.Range(0, i) < 2)
            {
                houses[Random.Range(0, houses.Length)].Order();
            }
            else
            {
                break;
            }
        }
        ordersAmountLevel++;
    }

    public void powerInput()
    {
        Debug.Log("Power Step: ");
        foreach (var item in powerSources)
        {
            if (_powerLevel < maxPowerLevel)
            {
                powerLevel += item.powerIncrement;
            }
            else
            {
                break;
            }
        }
    }
}
