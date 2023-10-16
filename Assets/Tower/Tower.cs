using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetLocator))]
public class Tower : MonoBehaviour
{
    [Tooltip("Ÿ�� ��ġ �� ���ſ� �ʿ��� ���")]
    [SerializeField] [Range(1, 1000)] int cost = 75;
    public bool CreateTower(Tower tower, Vector3 position)
    {
        // Bank�� ã�Ƽ�, cost�� ���
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
