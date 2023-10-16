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

    // 처음 방문하는 Node를 담는 변수
    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>(); // 이미 지나간 경로 확인용 딕셔너리

    // BFS 방향 설정
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

        // 시작시 시작위치와 도착지 위치 노드 설정
        startNode = new Node(startCoordinates, true);
        destinationNode = new Node(destinationCoordinates, true);
    }

    private void Start()
    {
        StartCoroutine(BFS());
    }

    // 인접 좌표를 확인하는 함수
    private void ExploreNeighbors()
    {
        // 1. Node들을 담을 수 있는 neighbors 리스트를 만든다.
        List<Node> neighbors = new List<Node>();
        // 2. direction 배열을 순회하며(방향을 확인하며)
        foreach(Vector2Int direction in direction)
        {
            // 3. gridManager의 Grid에 해당 좌표를 찾는다.
            Vector2Int neighborCoords = currentNode.coordinates + direction;
            // 4. 이웃하는 좌표가 있다면
            if(grid.ContainsKey(neighborCoords))
            {
                // 5. 해당 노드를 가져와서 neighbors에 저장한다.
                neighbors.Add(grid[neighborCoords]);
            }

            foreach(Node neighbor in neighbors)
            {
                // 방문하지 않은 좌표라면, reched에 해당 좌표를 추가하여 방문한 것으로 만들어준다.
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
        frontier.Enqueue(startNode); // 그래프의 시작 노드
        reached.Add(startCoordinates, startNode); // 이미 방문한 것을 확인

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
