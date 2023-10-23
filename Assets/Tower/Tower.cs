using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetLocator))]
public class Tower : MonoBehaviour
{
    [Tooltip("Ÿ�� ��ġ �� ���ſ� �ʿ��� ���")]
    [SerializeField] [Range(1, 1000)] int cost = 75;
    [Tooltip("Ÿ�� ������ Build Timer Interval")]
    [SerializeField][Range(0.5f, 10)] float buildInterval;
    List<GameObject> towerParts = new List<GameObject>();

    private void Start()
    {
        // ���۽� �θ� Ÿ���� �ڽĵ��� towerParts�� �߰��Ѵ�.
        foreach(Transform part in transform)
        {
            towerParts.Add(part.gameObject);

            // ó�� Ÿ�� ������ ��� ��Ʈ�� ��Ȱ��ȭ
            part.gameObject.SetActive(false);
        }

        StartCoroutine(StartBuildTimer());
    }

    // Ư�� �ֱ�� Ÿ���� ��ü�� ������� Ȱ��ȭ �ȴ�.
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
        // Bank�� ã�Ƽ�, cost�� ���
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
