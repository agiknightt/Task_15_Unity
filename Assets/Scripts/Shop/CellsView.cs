using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CellsView : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _moneyPerSecond;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;

    private Cell _cell;

    public event UnityAction<Cell, CellsView> SellButtonClick;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnButtonClick);
    } 
    
    public void Render(Cell cell)
    {
        _cell = cell;
        _name.text = cell.Name;
        _price.text = "Dollars: " + cell.Price.ToString();
        _moneyPerSecond.text = "Mh/s: " + cell.MoneyPerSecond.ToString();
        _icon.sprite = cell.Icon;       
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_cell, this);
    }
}
