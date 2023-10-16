using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] GameObject indicator;
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinationCoordinates;

    Node startNode;
    Node destinationNode;
    Node currentNode;

    // ó�� �湮�ϴ� Node�� ��� ����
    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>(); // �̹� ������ ��� Ȯ�ο� ��ųʸ�

    // BFS ���� ����
    Vector2Int[] direction = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null)
        {
            grid = gridManager.Grid;
        }

        // ���۽� ������ġ�� ������ ��ġ ��� ����
        startNode = new Node(startCoordinates, true);
        destinationNode = new Node(destinationCoordinates, true);
    }

    private void Start()
    {
        StartCoroutine(BFS());
    }

    // ���� ��ǥ�� Ȯ���ϴ� �Լ�
    private void ExploreNeighbors()
    {
        // 1. Node���� ���� �� �ִ� neighbors ����Ʈ�� �����.
        List<Node> neighbors = new List<Node>();
        // 2. direction �迭�� ��ȸ�ϸ�(������ Ȯ���ϸ�)
        foreach(Vector2Int direction in direction)
        {
            // 3. gridManager�� Grid�� �ش� ��ǥ�� ã�´�.
            Vector2Int neighborCoords = currentNode.coordinates + direction;
            // 4. �̿��ϴ� ��ǥ�� �ִٸ�
            if(grid.ContainsKey(neighborCoords))
            {
                // 5. �ش� ��带 �����ͼ� neighbors�� �����Ѵ�.
                neighbors.Add(grid[neighborCoords]);
            }

            foreach(Node neighbor in neighbors)
            {
                // �湮���� ���� ��ǥ���, reched�� �ش� ��ǥ�� �߰��Ͽ� �湮�� ������ ������ش�.
                if(!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
                {
                    reached.Add(neighbor.coordinates, neighbor);
                    frontier.Enqueue(neighbor);
                }
            }
        }
    }

    IEnumerator BFS()
    {
        frontier.Enqueue(startNode); // �׷����� ���� ���
        reached.Add(startCoordinates, startNode); // �̹� �湮�� ���� Ȯ��

        while(frontier.Count > 0)
        {
            currentNode = frontier.Dequeue();
            currentNode.isExplored = true;

            ExploreNeighbors();

            indicator.transform.position = new Vector3(currentNode.coordinates.x * 10, 0, currentNode.coordinates.y * 10);

            if (currentNode.coordinates == destinationCoordinates)
            {
                break;
            }
            
            yield return new WaitForSeconds(0.5f);
        }
    }
}
