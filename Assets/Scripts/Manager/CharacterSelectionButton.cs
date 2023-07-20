using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionButton : MonoBehaviour
{
    public int characterIndex; // Índice do personagem na lista de GameData
    public GameManager gameManager;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SelectCharacter);
    }

    private void SelectCharacter()
    {
       

        gameManager.currentCharacterIndex = characterIndex;
        gameManager.GoMarket();
        
    }
}