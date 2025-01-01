using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PLAYER");   
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("COLLIDE");
        if (other.CompareTag("ZombieArm")) {
            Debug.Log("DAÑO");
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
