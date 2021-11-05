using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyContainer;
    [SerializeField]
    private GameObject[] powerUps;

    private bool stopSpawning = false;
    void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
        StartCoroutine(PowerUpRoutine());
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        while (!stopSpawning)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-8, 8), 6f, 0), Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator PowerUpRoutine()
    {
        while (!stopSpawning)
        {
            float wait = Random.Range(5, 10);
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerUps[randomPowerUp], new Vector3(Random.Range(-8, 8), 6f, 0), Quaternion.identity);
            yield return new WaitForSeconds(wait);
        }
    }

    public void OnPlayerDeath()
    {
        stopSpawning = true;
    }
}
