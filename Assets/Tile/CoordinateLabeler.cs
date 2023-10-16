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
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Start()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = true;

        waypoint = GetComponentInParent<Waypoint>();
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
        if(waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockColor;
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z);
        label.text = $"{coordinates.x},{coordinates.y}";
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
