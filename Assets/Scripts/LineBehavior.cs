using UnityEngine;

public class LineBehavior : MonoBehaviour
{
    [SerializeField] public Vector3 p0;
    [SerializeField] public Vector3 p1;
    [SerializeField] public Vector3 p2;
    [SerializeField] public Vector3 p3;
    [SerializeField] public LineRenderer self;

    [SerializeField] public float duration = 3f;
    public float time;

    void Update()
    {
        LineRenderRender(self, time, duration, p0, p1, p2, p3);
    }

    public void LineRenderRender(LineRenderer self, float time, float duration, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        time += Time.deltaTime / duration;
        float t = Mathf.Clamp01(time);

        // Position
        transform.position = Bezier.GetPoint(p0, p1, p2, p3, t);

        // Rotation (look along tangent)
        Vector3 tangent = Bezier.GetFirstDerivative(p0, p1, p2, p3, t);
        transform.rotation = Quaternion.LookRotation(tangent);
        Bezier.DrawCurve(self, p0, p1, p2, p3, 50);
    }

    public Vector3 LineRenderFollow(float time, float duration, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float t = Mathf.Clamp01(time / duration);
        Vector3 point = Bezier.GetPoint(p0, p1, p2, p3, t);
        return point;
    }

}