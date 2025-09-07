using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody obj;
    [SerializeField]
    private float jumpForce = 100f;
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private Animator playerAnimator;
    private bool isGrounded;
    [SerializeField]
    private Collision enemy;
    [SerializeField]
    private EnnemyBehavior ennemy;
    [SerializeField]
    private PlayerHitboxBehavior hitbox;
    [SerializeField]
    private HealthBarBehavior healthBar;
    private int health;
    private float maxHealth;
    public int damage = 10;
    public bool attacking;
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
        var landed = isGrounded;
        if (landed != isGrounded)
        {
            if (!landed)
            {
                playerAnimator.SetFloat("Height", 1);
            }
            
        }
        if (obj.linearVelocity.y > 0)
        {
            playerAnimator.SetFloat("Height", -1);
            playerAnimator.SetFloat("Height", 0);
        }
        playerAnimator.SetFloat("xMove", 0);
        playerAnimator.SetFloat("yMove", 0);
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.01f, 0, 0); 
            playerAnimator.SetTrigger("Walking");
            playerAnimator.SetFloat("xMove", -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.01f, 0, 0);
            playerAnimator.SetTrigger("Walking");
            playerAnimator.SetFloat("xMove", 1);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 0.01f);
            playerAnimator.SetTrigger("Walking");
            playerAnimator.SetFloat("yMove", 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -0.01f);
            playerAnimator.SetTrigger("Walking");
            playerAnimator.SetFloat("yMove", -1);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            playerAnimator.SetTrigger("Attack");
        }

        if (hitbox.attackEnnemy == true && Input.GetKey(KeyCode.Q)) attacking = true;

        if (Input.GetMouseButton(1))
        {
            Vector3 forward = cameraTransform.forward;
            forward.y = 0;
            if (forward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(forward);
            }

        }

        if (ennemy.attacking && health > 0)
        {
            if (ennemy.attackrate < Time.time)
            {
                health -= ennemy.damage;
                healthBar.Change(ref health);
                ennemy.attackrate += 1;
            }

        }

        if (health <= 0)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            if (Input.GetKey(KeyCode.Space))
            {
                isGrounded = false;
                playerAnimator.SetTrigger("Jumping");
                obj.linearVelocity = Vector3.zero;
                obj.AddForce(new Vector3(0, jumpForce, 0));
            }
        }
    }
}
