using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(Tower))]
public class TargetLocator : MonoBehaviour
{
    [Tooltip("Ÿ������ ��ü�� ���� ȸ���ϴ� ���� ������Ʈ")]
    [SerializeField] Transform weapon;
    [Tooltip("Ÿ���� ���� ����")]
    [SerializeField] [Range(1, 200)] float range = 15f;
    [Tooltip("Ÿ���� ����(��ƼŬ)")]
    [SerializeField] ParticleSystem weaponParticle;
    Transform target;

    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    void Update()
    {
        FindClosestTarget();
        AimTarget();
    }

    private void FindClosestTarget()
    {
        EnemyMover[] enemies = FindObjectsOfType<EnemyMover>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(EnemyMover enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    private void AimTarget()
    {
        weapon.LookAt(target);

        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        // Target���� �Ÿ��� Range ���� ��� Attack(true)!, �ƴϸ� Attack(false)
        if(targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    // Attack �Լ��� emission�� �Ѱ� ���� �Լ�
    void Attack(bool isActive)
    {
        var emission = weaponParticle.emission;
        emission.enabled = isActive;
    }
}
