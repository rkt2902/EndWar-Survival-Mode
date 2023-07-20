using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharLabel : MonoBehaviour
{

    public GameManager gameManager;
    public TextMeshProUGUI label;

    // Start is called before the first frame update
    void Start()
    {  
        // Find the GameManager object by name
        GameObject gameManagerObj = GameObject.Find("GameManager");

        // Check if the GameManager object exists
        if (gameManagerObj != null)
        {
            // Get the GameManager component from the object
            gameManager = gameManagerObj.GetComponent<GameManager>();
        }
        else
        {
            Debug.LogError("GameManager not found in the scene!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        label.text = gameManager.gameData.characters[gameManager.currentCharacterIndex].characterName;
    }
}
