using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ƼŬ�� �浹���� �� �������� �Դ´�.
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 3;
    int currentHP = 0;
    
    void OnEnable()
    {
        currentHP = maxHP;
    }

    private void OnParticleCollision(GameObject other)
    {
        Damaged();
    }

    private void Damaged()
    {
        currentHP--;

        if(currentHP <= 0)
            gameObject.SetActive(false);
    }
}
