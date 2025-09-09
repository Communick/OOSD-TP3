using UnityEngine;

public static class Bezier
{
    // Quadratic Bezier (3 points)
    public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        float u = 1 - t;
        return u * u * p0 +
               2 * u * t * p1 +
               t * t * p2;
    }

    // Cubic Bezier (4 points)
    public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        float u = 1 - t;
        return u * u * u * p0 +
               3 * u * u * t * p1 +
               3 * u * t * t * p2 +
               t * t * t * p3;
    }

    // Optional: derivative for direction/velocity
    public static Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        return 2 * (1 - t) * (p1 - p0) +
               2 * t * (p2 - p1);
    }

    public static Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        float u = 1 - t;
        return 3 * u * u * (p1 - p0) +
               6 * u * t * (p2 - p1) +
               3 * t * t * (p3 - p2);
    }

// Method to render the curve into a LineRenderer
    public static void DrawCurve(LineRenderer lineRenderer, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, int resolution = 50)
    {
        if (lineRenderer == null) return;

        lineRenderer.positionCount = resolution + 1;

        for (int i = 0; i <= resolution; i++)
        {
            float t = i / (float)resolution;
            Vector3 point = GetPoint(p0, p1, p2, p3, t);
            lineRenderer.SetPosition(i, point);
        }
    }
}
