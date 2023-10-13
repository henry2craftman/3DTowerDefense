using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 파티클에 충돌했을 때 데미지를 입는다.
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 3;
    int currentHP = 0;
    Enemy enemy;
    
    void OnEnable()
    {
        currentHP = maxHP;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        Damaged();
    }

    private void Damaged()
    {
        currentHP--;

        if(currentHP <= 0)
        {
            gameObject.SetActive(false);
            enemy.RewardMoney();
        }
    }
}
