using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 월드 스페이스에 있는 모든 타일(노드)들을 관리
public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize; // ex) 3 x 3 = 9개의 타일
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }

    private void Awake()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        for(int x = 0; x < gridSize.x; x++) 
        {
            for(int y = 0 ; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));
                Debug.Log(grid[coordinates].coordinates + " = " + grid[coordinates].isWalkable);
            }
        }
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }

        return null;
    }
}
