using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Settings")]
    [SerializeField] private GameObject[] playerLifes;

    [Header("Coins")]
    [SerializeField] private TextMeshProUGUI coinTMP;

    private void Update()
    {
        UpdateCoins();
    }

    // Updates the coins
    private void UpdateCoins()
    {
        coinTMP.text = CoinManager.Instance.TotalCoins.ToString();
    }

    // Updates the player lifes
    private void OnPlayerLifes(int currentLifes)
    {
        for (int i = 0; i < playerLifes.Length; i++)
        {
            if (i < currentLifes) // Total is 3, so value = 2
            {
                playerLifes[i].gameObject.SetActive(true);
            }
            else
            {
                playerLifes[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnEnable()
    {
        Health.OnLifesChanged += OnPlayerLifes;
    }

    private void OnDisable()
    {
        Health.OnLifesChanged -= OnPlayerLifes;
    }
}
