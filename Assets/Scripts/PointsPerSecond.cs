using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsPerSecond : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _pointsPerSecond;

    private int _pointPerSecond = 0;
    private float waitTime = 1;

    private void Start()
    {
        _pointsPerSecond.text = "Mh/s : " + _pointPerSecond.ToString();
        StartCoroutine(FarmPerSecond());
    }

    private IEnumerator FarmPerSecond()
    {
        yield return new WaitForSeconds(waitTime);
        _player.AddMoney(_pointPerSecond);
        _pointsPerSecond.text = "Mh/s : " + _pointPerSecond.ToString();
        StartCoroutine(FarmPerSecond());
    }
    
    public void AddPointsPerSecond(int points)
    {
        _pointPerSecond += points;
    }
}
