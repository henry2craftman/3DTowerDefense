using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetLocator))]
public class Tower : MonoBehaviour
{
    [Tooltip("타워 설치 시 구매에 필요한 비용")]
    [SerializeField] [Range(1, 1000)] int cost = 75;
    [Tooltip("타워 생성시 Build Timer Interval")]
    [SerializeField][Range(0.5f, 10)] float buildInterval;
    List<GameObject> towerParts = new List<GameObject>();

    private void Start()
    {
        // 시작시 부모 타워의 자식들을 towerParts에 추가한다.
        foreach(Transform part in transform)
        {
            towerParts.Add(part.gameObject);

            // 처음 타워 생성시 모든 파트를 비활성화
            part.gameObject.SetActive(false);
        }

        StartCoroutine(StartBuildTimer());
    }

    // 특정 주기로 타워의 몸체가 순서대로 활성화 된다.
    IEnumerator StartBuildTimer()
    {
        foreach (GameObject part in towerParts)
        {
            part.SetActive(true);

            yield return new WaitForSeconds(buildInterval);
        }
    }

    public bool CreateTower(Tower tower, Vector3 position)
    {
        // Bank를 찾아서, cost를 출금
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null) return false;

        if(bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(cost);
            
            return true;
        }

        return false;
    }




}
