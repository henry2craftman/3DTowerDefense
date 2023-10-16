using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// 계좌 잔액을 보관, 입금, 인출
public class Bank : MonoBehaviour
{
    [Tooltip("현재 은행이 가지고 있는 잔고를 표현하기 위한 TMPro Text")]
    [SerializeField] TextMeshProUGUI balanceText;
    [Tooltip("시작시 설정하게 되는 잔고")]
    [SerializeField] int startBalance = 150;
    [Tooltip("현재 잔고")]
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }
    private void Awake()
    {
        currentBalance = startBalance;
        UpdateBalanceText();
        DontDestroyOnLoad(gameObject);
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
        currentBalance -= Mathf.Abs(amount);
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
