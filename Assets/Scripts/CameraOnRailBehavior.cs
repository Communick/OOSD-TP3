using UnityEngine;

public class CameraOnRailBehavior : MonoBehaviour
{
    [SerializeField]
    private LineBehavior line;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        line.LineRenderFollow(line.time, line.duration, line.p0, line.p1, line.p2, line.p3);
    }
}
