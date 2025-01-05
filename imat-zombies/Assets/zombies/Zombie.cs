using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float damage = 10.0f;
    [SerializeField] private float life = 100.0f;

    private GameObject target;
    private bool attacking;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    void Update()
    {
        ZombieBehaviour();
    }

    void ZombieBehaviour() {
        if (Vector3.Distance(transform.position, target.transform.position) > 5) {
            
            RotateTowardsTarget();
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            startWalk();

        }
        else {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !attacking) {
                RotateTowardsTarget();
                transform.Translate(Vector3.forward * 2 * speed * Time.deltaTime);
                startRun();

            }
            else {
                startAttack();
                attacking = true;
            }
        }
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
