using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [Tooltip("������ Ÿ�� ������ �� Tower ������Ʈ")]
    [SerializeField] Tower towerPrefab;
    [Tooltip("Ÿ�Ͽ� Ÿ�� ���� ���� ���θ� ��Ÿ���� ����")]
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }

    public bool GetIsPlaceable()
    {
        return isPlaceable;
    }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            
            isPlaceable = !isPlaced;
        }
    }
}
