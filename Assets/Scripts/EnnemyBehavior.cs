using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody obj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obj.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
