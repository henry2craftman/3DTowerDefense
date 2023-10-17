using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public Vector2Int coordinates; // Ÿ���� ��ǥ�� ����
    public bool isWalkable; // ���� ���� �� �ִ� �������� ����
    public bool isEnemyWaking; // ���� ���� �� �ִ� �������� ����
    public bool isExplored; // Ž���� �̷���� �������� ����
    public bool isPath; // ��� ���� ����
    public Node connectedTo; // ���� ����� ��� ���� ����

    public Node(Vector2Int coordinates, bool isWakable)
    {
        this.coordinates = coordinates;
        this.isWalkable = isWakable;
    }
}
