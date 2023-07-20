using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] enemies;
    public int initialEnemiesPerWave = 10;
    public int wavesToWin = 3;
    public float initialCooldownDuration = 5f;
    public float waveCooldown = 4f;
    public float pauseBetweenWaves = 6f;
    public float gameEndDelay = 3f;
    public WaveBar waveBar;

    public int currentWave = 0;
    private int enemiesSpawned = 0;
    public bool isWaveActive = false;
    private bool isCooldown = true;
    private float timeBetweenWaves = 3f;
    private bool win = false;

    private void Start()
    {
        
        StartCoroutine(StartNextWaveWithCooldown());
      
    }

    private IEnumerator StartNextWaveWithCooldown()
    {
        yield return new WaitForSeconds(initialCooldownDuration);
        isCooldown = false;

        while (currentWave < wavesToWin)
        {
            if (!isWaveActive)
            {
                StartNextWave();
                yield return new WaitForSeconds(timeBetweenWaves);
            }

            yield return null;
        }

        StartCoroutine(WaitForGameEndDelay());
    }

    private void StartNextWave()
    {
        currentWave++;
       
        enemiesSpawned = 0;
        isWaveActive = true;

        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        int enemiesPerWave = initialEnemiesPerWave + (currentWave - 1) * 2;

        while (enemiesSpawned < enemiesPerWave)
        {
            SpawnEnemy();
            enemiesSpawned++;

            if (enemiesSpawned >= enemiesPerWave)
            {
                break;
            }

            float spawnDelay = Random.Range(0.3f, 2.5f);
            yield return new WaitForSeconds(spawnDelay);
        }

        yield return new WaitForSeconds(pauseBetweenWaves);

        isWaveActive = false;
        isCooldown = true;

        if (currentWave == wavesToWin)
        {
            win = true;
            Debug.Log("You won the game!");
        }
    }

    private void SpawnEnemy()
    {
        Vector3 pos = new Vector3(Random.Range(-3, 4), 0.91f, -3f);
        int index = Random.Range(0, enemies.Length);
        Instantiate(enemies[index], pos, Quaternion.identity);
    }

   

    private IEnumerator WaitForGameEndDelay()
    {
        yield return new WaitForSeconds(gameEndDelay);

        // Handle game end logic here
    }
}
