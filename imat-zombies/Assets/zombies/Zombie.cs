using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Zombie : MonoBehaviour
{
    private Animator animator;
    protected float speed = 1.0f;
    protected float damage = 10.0f;
    protected float maxLife = 100f;
    private float currentLife = 100.0f;

    [Header("Ground Detection")]
    public Transform GroundCheck;
    public float GroundDistance = 0.2f;  // Detection radius for ground
    public LayerMask GroundMask;
    private bool isGrounded;

    private Rigidbody rb;
    private GameObject target;
    private bool attacking;

    public event Action OnDeath;

    void Start() {

        currentLife = maxLife;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        // Ensure Rigidbody is properly set up
        rb.useGravity = false;  // We'll handle gravity manually
        rb.constraints = RigidbodyConstraints.FreezeRotation;  // Prevent tipping

        target = GameObject.Find("FPS");
    }

    void FixedUpdate() {
        HandleGroundCheck();
        ApplyGravity();
    }

    void Update() {
        ZombieBehaviour();
    }

    void HandleGroundCheck() {
        // Perform ground check using Physics.CheckSphere
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGrounded && rb.velocity.y < 0f) {
            rb.velocity = new Vector3(rb.velocity.x, -2f, rb.velocity.z);  // Stick to the ground
        }
    }

    void ApplyGravity() {
        if (!isGrounded) {
            rb.velocity += Vector3.up * Physics.gravity.y * Time.fixedDeltaTime;  // Apply gravity
        }
    }
    // Function to apply damage
    public void TakeDamage(float damage) {
        currentLife -= damage;
        Debug.Log($"Zombie took {damage} damage. Current life: {currentLife}");

        if (currentLife <= 0f) {
            Die();
        }
    }

    private void Die() {
        // Notify listeners (e.g., RoundManager, ZombieSpawner)
        OnDeath?.Invoke();

        Destroy(gameObject);
    }
    void ZombieBehaviour() {
        if (Vector3.Distance(transform.position, target.transform.position) > 5) {
            RotateTowardsTarget();
            Move(speed);
            startWalk();
        }
        else {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !attacking) {
                RotateTowardsTarget();
                Move(speed * 2);
                startRun();
            }
            else {
                startAttack();
                attacking = true;
            }
        }
    }

    private void Move(float moveSpeed) {
        Vector3 moveDirection = transform.forward * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDirection);
    }

    private void startWalk() {
        animator.SetBool("walk", true);
        animator.SetBool("run", false);
        animator.SetBool("attack", false);
    }

    private void startRun() {
        animator.SetBool("run", true);
        animator.SetBool("walk", false);
        animator.SetBool("attack", false);
    }

    private void startAttack() {
        animator.SetBool("attack", true);
        animator.SetBool("walk", false);
        animator.SetBool("run", false);
    }

    private void RotateTowardsTarget() {
        Vector3 lookPos = GetTargetDirection();
        RotateTowardsDirection(lookPos);
    }

    private void RotateTowardsDirection(Vector3 lookPos) {
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
    }

    private Vector3 GetTargetDirection() {
        Vector3 targetDirection = target.transform.position - transform.position;
        targetDirection.y = 0;
        return targetDirection;
    }

    public void EndAttack() {
        attacking = false;
        EndAttackAnimation();
    }

    public void EndAttackAnimation() {
        animator.SetBool("attack", false);
    }
}
