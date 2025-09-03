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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obj.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerAnimator.SetFloat("xMove", 0);
        playerAnimator.SetFloat("yMove", 0);
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.1f, 0, 0); 
            playerAnimator.SetTrigger("Walking");
            playerAnimator.SetFloat("xMove", -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.1f, 0, 0);
            playerAnimator.SetTrigger("Walking");
            playerAnimator.SetFloat("xMove", 1);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 0.1f);
            playerAnimator.SetTrigger("Walking");
            playerAnimator.SetFloat("yMove", 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -0.1f);
            playerAnimator.SetTrigger("Walking");
            playerAnimator.SetFloat("yMove", -1);
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 forward = cameraTransform.forward;
            forward.y = 0;
            if (forward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(forward);
            }

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(KeyCode.Space) && collision.gameObject.CompareTag("Ground"))
        {
            playerAnimator.SetTrigger("Jumping");
            obj.linearVelocity = Vector3.zero;
            obj.AddForce(new Vector3(0, jumpForce, 0));
        }
    }
}
