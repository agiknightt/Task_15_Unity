using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellAchievements : MonoBehaviour
{
    [SerializeField] private int _sum;
    [SerializeField] private int _moneyPerClick;
    [SerializeField] private Sprite _icon;

    private bool _isReceived = false;

    public int Sum => _sum;
    public int MoneyPerSecond => _moneyPerClick;
    public Sprite Icon => _icon;
}
