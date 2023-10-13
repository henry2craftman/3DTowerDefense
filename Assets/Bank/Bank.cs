using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// 계좌 잔액을 보관, 입금, 인출
public class Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI balanceText;
    [SerializeField] int startBalance = 150;
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }
    private void Awake()
    {
        currentBalance = startBalance;
        UpdateBalanceText();
    }

    private void UpdateBalanceText()
    {
        balanceText.text = "Gold: " + currentBalance;
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateBalanceText();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= amount;
        UpdateBalanceText();

        if (currentBalance < 0)
        {
            // 패배했습니다.
            Debug.Log("패배했습니다...");
            ReloadScene();
        }
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
