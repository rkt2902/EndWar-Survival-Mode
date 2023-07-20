using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBoostPower : MonoBehaviour
{
    public float moneyBoostPercentage = 0.25f; // Porcentagem de aumento do valor de dinheiro recebido
    public float abilityDuration = 20f; // Duração da habilidade em segundos

    private bool abilityActive = false;

    public void ActivateMoneyBoostPower()
    {
        if (!abilityActive)
        {
            abilityActive = true;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                Death enemyDeath = enemy.GetComponent<Death>();
                if (enemyDeath != null)
                {
                    int originalValue = enemyDeath.enemyValue;
                    int boostedValue = Mathf.FloorToInt(originalValue * (1 + moneyBoostPercentage));
                    enemyDeath.enemyValue = boostedValue;
                }
            }

            Invoke("DeactivateMoneyBoostPower", abilityDuration);
        }
    }

    private void DeactivateMoneyBoostPower()
    {
        abilityActive = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            Death enemyDeath = enemy.GetComponent<Death>();
            if (enemyDeath != null)
            {
                int boostedValue = enemyDeath.enemyValue;
                int originalValue = Mathf.FloorToInt(boostedValue / (1 + moneyBoostPercentage));
                enemyDeath.enemyValue = originalValue;
            }
        }
    }
}


