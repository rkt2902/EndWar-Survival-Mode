using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlowPower : MonoBehaviour
{
    public float movementSpeedReductionPercentage = 0.25f; 

    public void UseEnemySlowPower()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            EnemyMove enemyMove = enemy.GetComponent<EnemyMove>();
            if (enemyMove != null)
            {
                enemyMove.DecreaseMovementSpeed(movementSpeedReductionPercentage);
            }
        }
    }
}
