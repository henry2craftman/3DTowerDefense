using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [Tooltip("생성할 타워 프리펩 중 Tower 컴포넌트")]
    [SerializeField] Tower towerPrefab;
    [Tooltip("타일에 타워 생성 가능 여부를 나타내는 변수")]
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
