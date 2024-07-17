using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    public Transform pointPrefab;

    [SerializeField]
    public int resolution = 10;

    Transform[] points;
    float step;

    void Awake()
    {
        step = 2.0f / resolution;
        Vector3 scale = Vector3.one * step;

        points = new Transform[resolution];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = Instantiate(pointPrefab);
            points[i].localScale = scale;
            points[i].SetParent(transform);
        }
    }

    void Update()
    {
        float time = Time.time;
        
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.x = (i + 0.5f) * step - 1.0f;
            position.y = Mathf.Sin(Mathf.PI * position.x + time);
            point.localPosition = position;
        }
    }
}
