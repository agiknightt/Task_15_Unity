using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private TMP_Text _moneyPerSecond;
    [SerializeField] private GameObject _effect;
    [SerializeField] private GameObject _button;

    private PointsPerSecond _pointsPerSecond;
    private int _moneyPerClick = 1;

    public int TotalMoney { get; private set; } = 0;
    public int Money { get; private set; } = 0;

    private void Start()
    {
        _money.text = "Dollars : " + Money.ToString();
        TotalMoney = Money;
        OfflineTime();
    }

    private void OfflineTime()
    {
        TimeSpan absenceTime;
        if (PlayerPrefs.HasKey("LastSession"))
        {
            absenceTime = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));
            Money += (int)absenceTime.TotalSeconds;
            TotalMoney = Money;
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
        }
    }
#else
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
    }
#endif

    public void AddMoneyPerClick()
    {
        Money += _moneyPerClick;
        _money.text = "Dollars : " + Money.ToString();
        Instantiate(_effect, _button.GetComponent<RectTransform>().position.normalized, Quaternion.identity);
        _button.GetComponent<AudioSource>().Play();
        TotalMoney = Money;
    }

    public void AddMoney(int money)
    {
        Money += money;
        _money.text = "Dollars : " + Money.ToString();
        TotalMoney = Money;
    }

    public void BuyMoneyPerSecond(Cell cell)
    {
        Money -= cell.Price;
        _pointsPerSecond.AddPointsPerSecond(cell.MoneyPerSecond);
    }

    public void GetAchievement(CellAchievements cellAchievements)
    {
        _moneyPerClick += cellAchievements.MoneyPerSecond;
    }
}
