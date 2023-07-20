using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPriceReductionPower : MonoBehaviour
{
    public SetTower towerScript;
    public float abilityDuration = 20f;

    private bool isAbilityActive = false;
    private int[] originalPrices;

    public void ActivatePriceReductionAbility()
    {
        if (!isAbilityActive)
        {
            isAbilityActive = true;

            // Save the original tower prices
            originalPrices = (int[])towerScript.prices.Clone();

            // Reduce the tower prices by 25%
            for (int i = 0; i < towerScript.prices.Length; i++)
            {
                towerScript.prices[i] = Mathf.RoundToInt(towerScript.prices[i] * 0.75f);
            }

            // Schedule the reset of tower prices after the ability duration
            Invoke("ResetTowerPrices", abilityDuration);
        }
    }

    private void ResetTowerPrices()
    {
        isAbilityActive = false;

        // Restore the original tower prices
        for (int i = 0; i < towerScript.prices.Length; i++)
        {
            towerScript.prices[i] = originalPrices[i];
        }
    }
}


