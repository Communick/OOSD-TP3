using UnityEngine;

public class PlayerHitboxBehavior : MonoBehaviour
{
    public bool attackEnnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackEnnemy = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy")) attackEnnemy = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ennemy")) attackEnnemy = false;
    }
}