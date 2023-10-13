using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int moneyReward = 25;
    [SerializeField] int moneyPanalty = 25;

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
