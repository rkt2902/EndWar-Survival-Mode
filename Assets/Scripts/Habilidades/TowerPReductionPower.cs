using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowerPReductionPower : MonoBehaviour
{
    public Button abilityButton;
    public SetTower towerScript;

    private bool isAbilityActive = false;
    private int[] originalPrices;
    private bool isAbilityUsed = false;

    private void Start()
    {
        abilityButton.onClick.AddListener(ActivateTowerPriceReductionAbility);
    }

    private void ActivateTowerPriceReductionAbility()
    {
        if (!isAbilityActive && !isAbilityUsed)
        {
            isAbilityActive = true;
            isAbilityUsed = true;

            // Save the original tower prices
            originalPrices = (int[])towerScript.prices.Clone();

            // Reduce the tower prices by 25%
            for (int i = 0; i < towerScript.prices.Length; i++)
            {
                towerScript.prices[i] = Mathf.RoundToInt(towerScript.prices[i] * 0.75f);
            }

            // Disable the ability button
            abilityButton.interactable = false;
        }
    }

    private void Update()
    {
        // Check if the ability has been used and the level has ended
        if (!isAbilityActive && isAbilityUsed )
        {
            // Deactivate the ability
            isAbilityUsed = false;

            // Restore the original tower prices
            for (int i = 0; i < towerScript.prices.Length; i++)
            {
                towerScript.prices[i] = originalPrices[i];
            }
        }
    }
}
