using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody obj;
    [SerializeField]
    private PlayerDetectionBehavior lookZone;
    [SerializeField]
    private Rigidbody player;
    [SerializeField]
    private Animator skelet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obj.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (lookZone.playerSeen == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position - new Vector3(1, 0, 1), 0.005f);
            skelet.SetFloat("Speed", 1);
        }
        else skelet.SetFloat("Speed", 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            skelet.SetTrigger("SplashAttack");
        }
    }


}
