using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CellViewAchievements : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _moneyPerClick;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;

    private CellAchievements _cell;

    public event UnityAction<CellAchievements, CellViewAchievements> AddMoneyPerClick;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Render(CellAchievements cell)
    {
        _cell = cell;
        _name.text = $"Для достижения нужно набрать {cell.Sum} Dollars. ";
        _moneyPerClick.text = $"Вы получите +{cell.MoneyPerSecond} к клику";
        _icon.sprite = cell.Icon;
    }

    private void OnButtonClick()
    {
        AddMoneyPerClick?.Invoke(_cell, this);
    }

    public void DestroyCell()
    {
        Destroy(gameObject);
    }
}
