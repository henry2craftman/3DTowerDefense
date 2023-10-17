using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �����̽��� �ִ� ��� Ÿ��(���)���� ����
public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize; // ex) 3 x 3 = 9���� Ÿ��
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }

    [SerializeField] int unityGridSize = 10;
    public int UnityGridSize { get { return unityGridSize; } }

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

    // ��带 ���� �ɾ �� ���� ����� �Լ�
    public void BlockNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
        }
    }

    // World -> Grid ��ǥ
    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);

        return coordinates;
    }

    // Grid ��ǥ -> World
    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x * unityGridSize;
        position.z = coordinates.y * unityGridSize;

        return position;
    }

    // ���� ���� ������ ���� ������� �ʱ�ȭ
    public void ResetNode()
    {
        foreach (KeyValuePair<Vector2Int, Node> node in grid)
        {
            node.Value.connectedTo = null;
            node.Value.isExplored = false;
            node.Value.isPath = false;
        }
    }
}
