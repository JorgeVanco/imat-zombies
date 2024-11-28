using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
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

    // Update is called once per frame
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
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * Time.deltaTime);
                    animator.SetBool("walk", true);
                    break;
            }
        }
        else {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !attacking) {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
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

    public void EndAnimation() {
        animator.SetBool("attack", false);
        attacking = false;
    }
}
