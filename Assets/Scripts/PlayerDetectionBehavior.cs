using UnityEngine;

public class PlayerDetectionBehavior : MonoBehaviour
{

    public bool playerSeen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSeen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) playerSeen = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) playerSeen = false;
    }
}
