using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBoostButton : MonoBehaviour
{
    private Button button;
    private MoneyBoostPower moneyBoostPower;

    private void Start()
    {
        button = GetComponent<Button>();
        moneyBoostPower = FindObjectOfType<MoneyBoostPower>();

        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        moneyBoostPower.ActivateMoneyBoostPower();
        button.interactable = false; 
    }
}
