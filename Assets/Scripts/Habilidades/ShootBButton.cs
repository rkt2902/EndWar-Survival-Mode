using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBButton : MonoBehaviour
{
    private Button button;
    private ShootBoostPower shootBoostPower;

    private void Start()
    {
        button = GetComponent<Button>();
        shootBoostPower = FindObjectOfType<ShootBoostPower>();

        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        shootBoostPower.UseShootBoostPower();
        button.interactable = false; // Desativa o botão após o uso da habilidade
    }
}

