using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBar : MonoBehaviour
{
    public Slider slider;
    public float transitionDuration = 1f;

    private WaveManager waveManager;
    private int currentWave;
    private int maxWaves;
    private float transitionTimer;
    private float startWaveValue; // Armazena o valor inicial da wave no momento da transição

    private void Start()
    {
        waveManager = FindObjectOfType<WaveManager>();
        if (waveManager != null)
        {
            currentWave = 0;
            maxWaves = waveManager.wavesToWin;
            slider.minValue = 0;
            slider.maxValue = maxWaves;
            slider.value = currentWave;
        }
        else
        {
            Debug.LogError("WaveManager not found in the scene!");
        }
    }

    private void Update()
    {
        if (waveManager != null)
        {
            UpdateLevelProgress();
        }
    }

    private void UpdateLevelProgress()
    {
        if (currentWave < waveManager.currentWave)
        {
            currentWave = waveManager.currentWave;
            startWaveValue = slider.value; // Armazena o valor inicial da wave no momento da transição
            transitionTimer = 0f;
        }

        if (currentWave < maxWaves)
        {
            transitionTimer += Time.deltaTime;
            float t = Mathf.Clamp01(transitionTimer / transitionDuration);
            slider.value = Mathf.Lerp(startWaveValue, waveManager.currentWave, t);
        }
        else if (slider.value < maxWaves)
        {
            transitionTimer += Time.deltaTime;
            float t = Mathf.Clamp01(transitionTimer / transitionDuration);
            slider.value = Mathf.Lerp(startWaveValue, maxWaves, t);
        }
    }
}