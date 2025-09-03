using Unity.InferenceEngine;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private float minFov = 15f;
    private float maxFov = 90f;
    private float sensitivity = -10f;
    private float fov;
    private float yaw = 0f;
    private float pitch = 20f;
    private float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distance = transform.position.z;
        fov = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1)) 
        {
            yaw += Input.GetAxis("Mouse X") * sensitivity;
            pitch -= Input.GetAxis("Mouse Y") * sensitivity;
            pitch = Mathf.Clamp(pitch, 0f, 60f);

            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
            Vector3 offset = rotation * new Vector3(0, 0, distance);

            transform.position = player.position + offset;
            transform.LookAt(player.position);
        }

        if (Input.GetMouseButton(0))
        {
            yaw += Input.GetAxis("Mouse X") * sensitivity;
            pitch -= Input.GetAxis("Mouse Y") * sensitivity;
            pitch = Mathf.Clamp(pitch, 0f, 60f);

            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
            Vector3 offset = rotation * new Vector3(0, 0, distance);

            transform.position = player.position + offset;
            transform.LookAt(player.position);
        }
    }
}
