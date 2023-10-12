using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// ���� �������� Ÿ�� ���� ��ġ�� ǥ��
[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    void Start()
    {
        label = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
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
