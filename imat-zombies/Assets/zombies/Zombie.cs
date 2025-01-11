using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Zombie : MonoBehaviour, IDamageable
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

    [Header("Movement Physics")]
    private float fallVelocity = 0f;  // Track vertical velocity separately
    private readonly float gravityStrength = -20f;  // Stronger than default Unity gravity
    private readonly float groundedGravity = 0f;   // Small downward force when grounded
    private readonly float terminalVelocity = -50f; // Maximum fall speed

    private Rigidbody rb;
    private GameObject target;
    private bool attacking;

    public event Action OnDeath;

    void Start() {
        currentLife = maxLife;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        // Keep using custom gravity but maintain other physics
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        target = GameObject.Find("FPS");
    }


    void Update() {
        ZombieBehaviour();
    }
    void FixedUpdate() {
        HandleGroundCheck();
        ApplyImprovedGravity();
    }

    void HandleGroundCheck() {
        // Check if the zombie is grounded
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
    }

    void ApplyImprovedGravity() {
        if (isGrounded) {
            // When grounded, apply a small constant force to keep the zombie stuck to the ground
            fallVelocity = groundedGravity;
        }
        else {
            // When in air, accelerate downward but don't exceed terminal velocity
            fallVelocity += gravityStrength * Time.fixedDeltaTime;
            fallVelocity = Mathf.Max(fallVelocity, terminalVelocity);
        }

        // Apply the vertical velocity
        Vector3 currentVelocity = rb.velocity;
        currentVelocity.y = fallVelocity;
        rb.velocity = currentVelocity;
    }

    public void TakeDamage(float damageAmount) {
        currentLife -= damageAmount;

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
            if (Vector3.Distance(transform.position, target.transform.position) > 1.5f && !attacking) {
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
    void OnTriggerEnter(Collider other) {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null) {
            playerHealth.TakeDamage(damage);
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
