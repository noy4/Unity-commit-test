﻿using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public PolygonCollider2D polygon;

    List<Vector2> points;

    public void UpdateLine(Vector2 mousePos)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }

        if (Vector2.Distance(points.Last(), mousePos) > .1f)
            SetPoint(mousePos);
    }

    public void CloseLine()
    {
        Vector2 vector = new Vector2(points.First().x, points.First().y);
        SetPoint(vector);

        polygon.SetPath(0, points);
    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

    }

}