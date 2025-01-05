using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract base class for zombie factories
abstract class ZombieFactory
{
    protected GameObject zombiePrefab; // Protected to allow access in derived classes

    public ZombieFactory(GameObject prefab) {
        zombiePrefab = prefab;
    }

    public abstract GameObject CreateZombie();
}

// Factory for fast zombies
class FastZombieFactory : ZombieFactory
{
    public FastZombieFactory(GameObject prefab) : base(prefab) { }

    public override GameObject CreateZombie() {
        return Object.Instantiate(zombiePrefab);
    }
}

// Factory for slow zombies
class SlowZombieFactory : ZombieFactory
{
    public SlowZombieFactory(GameObject prefab) : base(prefab) { }

    public override GameObject CreateZombie() {
        return Object.Instantiate(zombiePrefab);
    }
}

// Factory for normal zombies
class NormalZombieFactory : ZombieFactory
{
    public NormalZombieFactory(GameObject prefab) : base(prefab) { }

    public override GameObject CreateZombie() {
        return Object.Instantiate(zombiePrefab);
    }
}
