using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Waypoint로 에네미를 이동
[RequireComponent(typeof(EnemyHealth))]
public class EnemyMover : MonoBehaviour
{
    [Tooltip("적의 이동 경로")]
    [SerializeField] List<Node> path = new List<Node>();
    [Tooltip("적의 이동 속도")]
    [SerializeField] [Range(1, 10)] float speed = 2f;
    float waitTime = 1f;
    Enemy enemy;

    PathFinder pathFinder;
    GridManager gridManager;

    void OnEnable()
    {
        FindPath();

        ReturnToStart();

        //InvokeRepeating("PrintWaypointName", 0, 1);
        StartCoroutine(FollowPath());
    }

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        pathFinder = FindObjectOfType<PathFinder>();
        gridManager = FindObjectOfType<GridManager>();
    }

    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathFinder.StartCoordinates);
    }

    private void FindPath()
    {
        path.Clear();

        path = pathFinder.GetNewPath();
    }

    IEnumerator FollowPath()
    {
        foreach (var path in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = gridManager.GetPositionFromCoordinates(path.coordinates);
            float travelPercent = 0f;

            transform.LookAt(endPos);

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
