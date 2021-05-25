using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Cell> _cells;
    [SerializeField] private Player _player;
    [SerializeField] private CellsView _template;
    [SerializeField] private GameObject _container;

    private void Start()
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            AddItem(_cells[i]);
        }
    }  
    
    private void AddItem(Cell cell)
    {        
        var view = Instantiate(_template, _container.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(cell);
    }

    private void OnSellButtonClick(Cell cell, CellsView cellsView)
    {
        TrySellMoneyPerSecond(cell, cellsView);
    }

    private void TrySellMoneyPerSecond(Cell cell, CellsView view)
    {
        if(cell.Price <= _player.Money)
        {
            _player.BuyMoneyPerSecond(cell);
            cell.IncreaseCost();
            view.Render(cell);
        }
    }
}
