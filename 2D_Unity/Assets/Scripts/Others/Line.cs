using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;

    void SetLine(Vector3 start, Vector3 end)
    {
        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);
        }
    }
}
