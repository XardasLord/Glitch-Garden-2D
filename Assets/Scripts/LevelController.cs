using Attackers;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private bool _gameTimerExpired;
    private int _numberOfAttackers = 0;

    private void Start()
    {
        GameTimer.OnExpired += GameTimerExpired;
        foreach (var attackerSpawner in FindObjectsOfType<AttackerSpawner>())
        {
            attackerSpawner.OnSpawned += AttackerSpawner_OnSpawned;
        }
    }

    private void GameTimerExpired()
    {
        _gameTimerExpired = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        foreach (var spawner in FindObjectsOfType<AttackerSpawner>())
        {
            spawner.StopSpawning();
        }
    }

    private void AttackerSpawner_OnSpawned()
        => _numberOfAttackers++;

    public void AttackerKilled()
    {
        _numberOfAttackers--;

        if (_numberOfAttackers <= 0 && _gameTimerExpired)
        {
            Debug.Log("End level now!");
        }
    }
}
