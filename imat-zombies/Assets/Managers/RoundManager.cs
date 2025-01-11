using System;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public event Action<int> OnRoundStarted;
    public event Action<int> OnRoundEnded;

    public event Action OnZombieKilledAction;

    private int currentRound = 1;
    private int zombiesToSpawn;
    private int zombiesRemaining;

    [SerializeField] private ZombieSpawner zombieSpawner;

    private void Start() {
        OnZombieKilledAction += OnZombieKilled;
        StartRound();
    }

    private void StartRound() {

        // Calculate the number of zombies based on the round
        zombiesToSpawn = currentRound * 2; // Example formula
        zombiesRemaining = zombiesToSpawn;

        OnRoundStarted?.Invoke(currentRound);

        // Spawn zombies for this round
        zombieSpawner.StartSpawning(zombiesToSpawn, OnZombieKilledAction);
    }

    private void OnZombieKilled() {
        zombiesRemaining--;
        // Check if the round is complete
        if (zombiesRemaining <= 0) {
            EndRound();
        }
    }

    private void EndRound() {
        OnRoundEnded?.Invoke(currentRound);
        // Prepare for the next round
        currentRound++;
        Invoke(nameof(StartRound), 10f); // Wait 10 seconds before starting the next round
    }
}
