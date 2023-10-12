using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Waypoint�� ���׹̸� �̵�
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0, 5)] float speed = 2f;
    float waitTime = 1f;

    void Start()
    {
        //InvokeRepeating("PrintWaypointName", 0, 1);
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (var waypoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(waypoint.transform);

            while(travelPercent < waitTime)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);

                yield return new WaitForEndOfFrame();
            }
        }
    }
}