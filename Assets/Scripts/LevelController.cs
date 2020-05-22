using System.Collections;
using Assets.Scripts;
using Attackers;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject winLabel;

    private bool _gameTimerExpired;
    private int _numberOfAttackers;

    private void Start()
    {
        GameTimer.OnExpired += GameTimerExpired;
        foreach (var attackerSpawner in FindObjectsOfType<AttackerSpawner>())
        {
            attackerSpawner.OnSpawned += AttackerSpawner_OnSpawned;
        }

        winLabel.SetActive(false);
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
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(4f);

        FindObjectOfType<LevelLoader>().LoadNextScene();
    }
}
