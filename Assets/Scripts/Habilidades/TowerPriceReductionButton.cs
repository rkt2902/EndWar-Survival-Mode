using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class TowerPriceReductionButton : MonoBehaviour
{
    public Button abilityButton;
    public TowerPriceReductionPower reductionPower;

    private bool isButtonInteractable = true;

    private void Start()
    {
        abilityButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (isButtonInteractable)
        {
            reductionPower.ActivatePriceReductionAbility();
            isButtonInteractable = false;
            abilityButton.interactable = false;
        }
    }
}
