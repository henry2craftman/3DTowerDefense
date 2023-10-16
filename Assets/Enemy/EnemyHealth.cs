using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
// 파티클에 충돌했을 때 데미지를 입는다.
public class EnemyHealth : MonoBehaviour
{
    [Tooltip("적의 최대 체력")]
    [SerializeField] [Range(1, 100)] int maxHP = 3;
    [Tooltip("적이 죽을 때 maxHP에 추가할 변수")]
    [SerializeField][Range(1, 100)] int difficultyInscrese = 1;
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
            maxHP += difficultyInscrese;
            enemy.RewardMoney();
        }
    }
}
