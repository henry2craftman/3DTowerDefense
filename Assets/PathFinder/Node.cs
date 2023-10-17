using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public Vector2Int coordinates; // 타일의 좌표를 저장
    public bool isWalkable; // 적이 걸을 수 있는 구간인지 여부
    public bool isEnemyWaking; // 적이 걸을 수 있는 구간인지 여부
    public bool isExplored; // 탐색이 이루어진 구간인지 여부
    public bool isPath; // 경로 인지 여부
    public Node connectedTo; // 이전 연결된 노드 정보 저장

    public Node(Vector2Int coordinates, bool isWakable)
    {
        this.coordinates = coordinates;
        this.isWalkable = isWakable;
    }
}
