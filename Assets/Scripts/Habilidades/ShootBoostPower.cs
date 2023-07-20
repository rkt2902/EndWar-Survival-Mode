using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootBoostPower : MonoBehaviour
{
    public float cooldownReductionPercentage = 0.25f; // Porcentagem de redução do cooldown
    public float abilityDuration = 20f; // Duração da habilidade em segundos

    private bool abilityUsed = false; // Flag para verificar se a habilidade foi usada

    private float originalCooldown; // Cooldown original antes da redução

    public void UseShootBoostPower()
    {
        if (!abilityUsed)
        {
            abilityUsed = true;
            GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

            foreach (GameObject tower in towers)
            {
                Shoot shoot = tower.GetComponent<Shoot>();
                if (shoot != null)
                {
                    originalCooldown = shoot.Cooldown; // Salva o cooldown original
                    shoot.ReduceCooldown(cooldownReductionPercentage);
                }
            }

            Invoke("ResetAbility", abilityDuration);
        }
    }

    private void ResetAbility()
    {
        abilityUsed = false;

        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

        foreach (GameObject tower in towers)
        {
            Shoot shoot = tower.GetComponent<Shoot>();
            if (shoot != null)
            {
                shoot.ResetCooldown(originalCooldown); // Restaura o cooldown original
            }
        }
    }
}
