using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
    [Tooltip("���� �׾��� ��� ������ ����")]
    [SerializeField] [Range(1, 10000)] int moneyReward = 25;
    [Tooltip("���� �׾��� ��� ������ ����")]
    [SerializeField] [Range(1, 1000)] int moneyPanalty = 25;

    Bank bank;

    private void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardMoney()
    {
        bank.Deposit(moneyReward);
    }

    public void StealMoney()
    {
        bank.Withdraw(moneyPanalty);
    }
}
