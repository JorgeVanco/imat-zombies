using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    private int rutine;
    public float timer;
    private Animator animator;
    private Quaternion angle;
    private float degree;

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
            animator.SetBool("run", false);
            timer += Time.deltaTime;
            if (timer >= 4) {
                rutine = Random.Range(0, 2);
                timer = 0;
            }
            switch (rutine) {
                case 0:
                    animator.SetBool("walk", false);
                    break;
                case 1:
                    degree = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, degree, 0);
                    rutine++;
                    break;
                case 2:
                    RotateTowardsTarget();
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 180f);
                    transform.Translate(Vector3.forward * Time.deltaTime);
                    animator.SetBool("walk", true);
                    break;
            }
        }
        else {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !attacking) {
                RotateTowardsTarget();
                animator.SetBool("walk", false);

                animator.SetBool("run", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                animator.SetBool("attack", false);
            }
            else {
                animator.SetBool("walk", false);
                animator.SetBool("run", false);

                animator.SetBool("attack", true);
                attacking = true;
            }
        }
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

    public void EndAnimation() {
        animator.SetBool("attack", false);
        attacking = false;
    }
}
