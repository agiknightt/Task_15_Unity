using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    [SerializeField] private List<CellAchievements> _cells;
    [SerializeField] private Player _player;
    [SerializeField] private CellViewAchievements _template;
    [SerializeField] private GameObject _container;

    private void Start()
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            AddItem(_cells[i]);
        }
    }

    private void AddItem(CellAchievements cell)
    {
        var view = Instantiate(_template, _container.transform);
        view.AddMoneyPerClick += GetAchievementOnButtonClick;
        view.Render(cell);
    }

    private void GetAchievementOnButtonClick(CellAchievements cell, CellViewAchievements cellsView)
    {
        TryGetAchievement(cell, cellsView);
    }

    private void TryGetAchievement(CellAchievements cell, CellViewAchievements view)
    {
        if (cell.Sum <= _player.TotalMoney)
        {
            _player.GetAchievement(cell);
            view.DestroyCell();
        }
    }
}
