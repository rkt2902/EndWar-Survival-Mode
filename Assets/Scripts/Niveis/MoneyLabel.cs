using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;

public class MoneyLabel : MonoBehaviour
{
    private GameManager gameManager;
    public TextMeshProUGUI label;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        label.text = "Money: " + gameManager.gameData.characters[gameManager.currentCharacterIndex].money;
    }
}
