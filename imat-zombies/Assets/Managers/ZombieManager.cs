using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    [SerializeField] private GameObject fastZombiePrefab;
    [SerializeField] private GameObject slowZombiePrefab;
    [SerializeField] private GameObject normalZombiePrefab;

    private ZombieFactory fastZombieFactory;
    private ZombieFactory slowZombieFactory;
    private ZombieFactory normalZombieFactory;

    private void Awake() {
        fastZombieFactory = new FastZombieFactory(fastZombiePrefab);
        slowZombieFactory = new SlowZombieFactory(slowZombiePrefab);
        normalZombieFactory = new NormalZombieFactory(normalZombiePrefab);
    }

    public GameObject SpawnFastZombie(Vector3 position) {
        GameObject fastZombie = fastZombieFactory.CreateZombie();
        fastZombie.transform.position = position;
        return fastZombie;
    }

    public GameObject SpawnSlowZombie(Vector3 position) {
        GameObject slowZombie = slowZombieFactory.CreateZombie();
        slowZombie.transform.position = position;
        return slowZombie;
    }

    public GameObject SpawnNormalZombie(Vector3 position) {
        GameObject normalZombie = normalZombieFactory.CreateZombie();
        normalZombie.transform.position = position;
        return normalZombie;
    }
}
