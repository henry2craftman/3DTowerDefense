using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
// ��ƼŬ�� �浹���� �� �������� �Դ´�.
public class EnemyHealth : MonoBehaviour
{
    [Tooltip("���� �ִ� ü��")]
    [SerializeField] [Range(1, 100)] int maxHP = 3;
    [Tooltip("���� ���� �� maxHP�� �߰��� ����")]
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
