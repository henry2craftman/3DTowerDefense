using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetLocator))]
public class Tower : MonoBehaviour
{
    [Tooltip("타워 설치 시 구매에 필요한 비용")]
    [SerializeField] [Range(1, 1000)] int cost = 75;
    public bool CreateTower(Tower tower, Vector3 position)
    {
        // Bank를 찾아서, cost를 출금
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null) return false;

        if(bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(cost);
            
            return true;
        }

        return false;
    }
}
