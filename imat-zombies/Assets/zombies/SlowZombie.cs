using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZombie : Zombie
{
    public void Start(){
        speed = 0.7f;
        damage = 15f;
        maxLife = 120f;
        base.Start();
    }
}
