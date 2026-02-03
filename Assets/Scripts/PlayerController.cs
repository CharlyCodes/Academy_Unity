using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool useSpriteFlip = true;

    private Vector2 moveInput;
    private Animator animator;
    private Transform spriteTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteTransform = animator.transform;
    }

    private void FixedUpdate()
    {
        Move();
        UpdateAnimation();
        HandleFlip();
    }

    private void Update()
    {
        //rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    private void UpdateAnimation()
    {
        bool isMoving = moveInput != Vector2.zero;
        animator.SetBool("isMoving", isMoving);
        animator.SetFloat("moveX", moveInput.x);
        animator.SetFloat("moveY", moveInput.y);
    }

    private void HandleFlip()
    {
        if(!useSpriteFlip) return;
        if (moveInput.x == 0) return;

        Vector3 scale = spriteTransform.localScale;
        scale.x = Mathf.Sign(moveInput.x);
        spriteTransform.localScale = scale;
    }
}
