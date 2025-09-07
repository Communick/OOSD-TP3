using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using System;

public class EnnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody obj;
    [SerializeField]
    private PlayerDetectionBehavior lookZone;
    [SerializeField]
    private Rigidbody rbPlayer;
    [SerializeField]
    private Animator skelet;
    [SerializeField]
    private EnnemyHitboxBehavior hitbox;
    public bool attacking;
    private int health;
    [SerializeField]
    private HealthBarBehavior healthBar;
    private float maxHealth;
    [SerializeField]
    private PlayerBehavior player;
    public int damage = 2;
    public float attackrate = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obj.useGravity = true;
        health = 100;
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetTarget(ref health, ref maxHealth);
        attacking = false;
        if (lookZone.playerSeen == true)
        {
            transform.LookAt(player.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, rbPlayer.position - new Vector3(1, 0, 1), 0.005f);
            skelet.SetFloat("Speed", 1);
        }
        else skelet.SetFloat("Speed", 0);

        if (hitbox.attackPlayer == true)
        {
            skelet.SetTrigger("SplashAttack");
            attacking = true;
        }

        if (player.attacking)
        {
            if (player.attackrate < Time.time)
            {
                health -= player.damage;
                healthBar.Change(ref health);
                player.attackrate += 3;
            }

        }
        Debug.Log(health);
        if (health <= 0)
        {
            attacking = false;
            Destroy(gameObject);
        }
    }
}
