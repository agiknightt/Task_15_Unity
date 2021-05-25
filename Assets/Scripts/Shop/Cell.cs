using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private int _moneyPerSecond;
    [SerializeField] private Sprite _icon;

    private float percentageAddition = 1.3f;

    public string Name => _name;
    public int Price => _price;
    public int MoneyPerSecond => _moneyPerSecond;
    public Sprite Icon => _icon;

    public void IncreaseCost()
    {
        _price = (int)(_price * percentageAddition);
    }
}
