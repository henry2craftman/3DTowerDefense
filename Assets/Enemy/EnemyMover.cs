using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Waypoint�� ���׹̸� �̵�
[RequireComponent(typeof(EnemyHealth))]
public class EnemyMover : MonoBehaviour
{
    [Tooltip("���� �̵� ���")]
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [Tooltip("���� �̵� �ӵ�")]
    [SerializeField] [Range(1, 10)] float speed = 2f;
    float waitTime = 1f;
    Enemy enemy;

    void OnEnable()
    {
        FindPath();

        ReturnToStart();

        //InvokeRepeating("PrintWaypointName", 0, 1);
        StartCoroutine(FollowPath());
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    private void FindPath()
    {
        path.Clear();

        GameObject pathParent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in pathParent.transform)
        {
            path.Add(child.GetComponent<Waypoint>());
        }
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

        FinishPath();
    }

    private void FinishPath()
    {
        enemy.StealMoney();
        gameObject.SetActive(false);
    }
}
