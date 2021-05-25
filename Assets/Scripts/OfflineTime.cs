using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineTime : MonoBehaviour
{
    [SerializeField] Player _player;

    private void Start()
    {
        OfflineFarm();
    }

    private void OfflineFarm()
    {
        TimeSpan absenceTime;
        if (PlayerPrefs.HasKey("LastSession"))
        {
            absenceTime = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));            
            _player.AddMoney((int)absenceTime.TotalSeconds);
        }
    }
}
