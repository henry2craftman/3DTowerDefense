using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem weaponParticle;

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
