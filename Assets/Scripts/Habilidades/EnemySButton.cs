using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySButton : MonoBehaviour
{
    private Button button;
    private EnemySlowPower slowPower;
    private bool abilityUsed = false;

    private void Start()
    {
        button = GetComponent<Button>();
        slowPower = FindObjectOfType<EnemySlowPower>();

        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (!abilityUsed)
        {
            slowPower.UseEnemySlowPower();
            abilityUsed = true;
            button.interactable = false; // Desativa o botão após o uso da habilidade
        }
    }
}
