using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBButton : MonoBehaviour
{
    private Button button;
    private HealthBoostPower healthBoost;


    private void Start()
    {
        button = GetComponent<Button>();
        healthBoost = FindObjectOfType<HealthBoostPower>();

        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        healthBoost.UseSpecialAbility();
        button.interactable = false; // Desativa o botão após o uso da habilidade
    }
}
