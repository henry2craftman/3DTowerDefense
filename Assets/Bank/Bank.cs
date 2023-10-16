using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// ���� �ܾ��� ����, �Ա�, ����
public class Bank : MonoBehaviour
{
    [Tooltip("���� ������ ������ �ִ� �ܰ� ǥ���ϱ� ���� TMPro Text")]
    [SerializeField] TextMeshProUGUI balanceText;
    [Tooltip("���۽� �����ϰ� �Ǵ� �ܰ�")]
    [SerializeField] int startBalance = 150;
    [Tooltip("���� �ܰ�")]
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
            // �й��߽��ϴ�.
            Debug.Log("�й��߽��ϴ�...");
            ReloadScene();
        }
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
