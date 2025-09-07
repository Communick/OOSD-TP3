using UnityEngine;

public class EnnemyHitboxBehavior : MonoBehaviour
{
    public bool attackPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) attackPlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) attackPlayer = false;
    }
}
