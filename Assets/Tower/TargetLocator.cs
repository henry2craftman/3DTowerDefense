using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(Tower))]
public class TargetLocator : MonoBehaviour
{
    [Tooltip("타워에서 물체를 향해 회전하는 무기 오브젝트")]
    [SerializeField] Transform weapon;
    [Tooltip("타워의 공격 범위")]
    [SerializeField] [Range(1, 200)] float range = 15f;
    [Tooltip("타워의 무기(파티클)")]
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
        // Target과의 거리가 Range 내에 들면 Attack(true)!, 아니면 Attack(false)
        if(targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    // Attack 함수는 emission을 켜고 끄는 함수
    void Attack(bool isActive)
    {
        var emission = weaponParticle.emission;
        emission.enabled = isActive;
    }
}
