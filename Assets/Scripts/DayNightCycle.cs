using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    private Light Light;
    [SerializeField]
    public float speed = 1.0f;
    [SerializeField]
    private Slider slider;
    private float checkTimeRevolution = 0.0f;
    private float rateRevolution = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speed = slider.value;
        if (checkTimeRevolution < Time.timeSinceLevelLoad)
        {
            transform.RotateAround(new Vector3(0, 0, 0), new Vector3(1, 0, 0), 0.1f);
            if (transform.rotation.x > 0 && transform.rotation.x <= 90)
            {
                Light.intensity += 0.01f;
                Light.intensity %= 25f;
            }
            
            checkTimeRevolution += rateRevolution/speed;
        }
    }
}
