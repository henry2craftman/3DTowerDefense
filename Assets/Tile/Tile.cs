using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Tooltip("생성할 타워 프리펩 중 Tower 컴포넌트")]
    [SerializeField] Tower towerPrefab;
    [Tooltip("타일에 타워 생성 가능 여부를 나타내는 변수")]
    [SerializeField] bool isPlaceable;

    GridManager gridManager;
    PathFinder pathFinder;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();
    }

    private void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlaceable)
            {
                // 적이 이동할 수 없도록 막는다.
                gridManager.BlockNode(coordinates);
            }
        }
    }

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
        // isPlaceable이거나 && 만약 타일 위로 Enemy가 지나가고 있지 않으면
        if (isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            
            isPlaceable = !isPlaced;

            if(isPlaced)
            {
                gridManager.BlockNode(coordinates);

                pathFinder.Broadcast();
            }
        }
    }
}
