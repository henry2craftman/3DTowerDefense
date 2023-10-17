using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// 월드 포지션의 타일 현재 위치를 표시
[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [Tooltip("TMPro label의 기본 색상")]
    [SerializeField] Color defaultColor = Color.white;
    [Tooltip("Tile에 배치 불가능 한 경우 TMPro label의 기본 색상")]
    [SerializeField] Color blockColor = Color.gray;
    [SerializeField] Color pathColor = Color.yellow;
    [SerializeField] Color exploredColor = new Color(1f, 0.5f, 0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    GridManager gridManager;


    void Start()
    {
        gridManager = FindObjectOfType<GridManager>();

        label = GetComponent<TextMeshPro>();
        label.enabled = true;

        DisplayCoordinates();
    }

    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        SetLabelColor();

        ToggleLabels();
    }

    private void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void SetLabelColor()
    {
        if (gridManager == null) return;

        Node node = gridManager.GetNode(coordinates);

        if (node == null) return;

        if(!node.isWalkable)
        {
            label.color = blockColor;
        }
        else if(node.isPath)
        {
            label.color = pathColor;
        }
        else if(node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);
        label.text = $"{coordinates.x},{coordinates.y}";
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
