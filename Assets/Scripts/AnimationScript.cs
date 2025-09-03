using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private float IdleIndex = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IdleIndex += 0.000001f;
        IdleIndex %= 1.0f;
        animator.SetFloat("Case", IdleIndex);
    }
}
