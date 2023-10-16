using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Tooltip("������ �� ������")]
    [SerializeField] GameObject enemyPrefab;
    [Tooltip("������ ���� ����(0~50)")]
    [SerializeField] [Range(0, 50)] int poolSize = 10;
    [Tooltip("���� ���� �ֱ�(0.1s~30s)")]
    [SerializeField][Range(0.1f, 30f)] float spawnTime = 1f;
    GameObject[] pool;

    void Awake()
    {
        CreatePool();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void CreatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0;  i < poolSize; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void EnableObjectInPool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
}
