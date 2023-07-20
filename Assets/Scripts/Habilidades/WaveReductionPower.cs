using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveReductionPower : MonoBehaviour
{
  /*  public Button abilityButton;
    public WaveManager waveManager;

    private bool isAbilityActive = false;
    private int originalEnemiesPerWave;

    private void Start()
    {
        abilityButton.onClick.AddListener(ActivateWaveReductionAbility);
    }

    private void ActivateWaveReductionAbility()
    {
        if (!isAbilityActive)
        {
            isAbilityActive = true;

            // Armazena o número original de inimigos por onda
            originalEnemiesPerWave = waveManager.enemiesPerWave;

            // Diminui o número de inimigos por onda em 20%
            waveManager.enemiesPerWave = Mathf.RoundToInt(waveManager.enemiesPerWave * 0.8f);

            // Desativa o botão da habilidade
            abilityButton.interactable = false;
        }
    }

    private void Update()
    {
        // Verifica se a wave atual terminou
        if (!waveManager.isWaveActive && isAbilityActive)
        {
            // Desativa a habilidade
            isAbilityActive = false;

            // Restaura o número original de inimigos por onda
            waveManager.enemiesPerWave = originalEnemiesPerWave;
        }

        if (waveManager.win)
        {
            // Ativa novamente o botão da habilidade
            abilityButton.interactable = true;
        }
    }*/
}
