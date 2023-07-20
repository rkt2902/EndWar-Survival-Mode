using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoostPower : MonoBehaviour
{

    public float healthBoostPercentage = 0.25f; // Porcentagem de aumento na defesa das torres

    private bool abilityUsed = false; // Flag para verificar se a habilidade foi usada

 

    public void UseSpecialAbility()
    {
        if (!abilityUsed)
        {
            abilityUsed = true;
            GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

            foreach (GameObject tower in towers)
            {
                Health health = tower.GetComponent<Health>();
                if (health != null)
                {
                    health.BoostHealth(healthBoostPercentage);
                }
            }
        }
    }
}
