using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastZombie : Zombie
{
    public void Start(){
        speed = 1.5f;
        damage = 7.0f;
        maxLife = 80.0f;
        base.Start();
    }
    
}
