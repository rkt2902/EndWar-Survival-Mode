using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectedTowerLabel : MonoBehaviour
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
        label.text = "Selected Towers:  " + gameManager.gameData.characters[gameManager.currentCharacterIndex].selectedTowers.Count +" / " +gameManager.gameData.characters[gameManager.currentCharacterIndex].maxSlots;

    }
}
