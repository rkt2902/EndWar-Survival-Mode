using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private GameManager gameManager;
    public int money;
    // Start is called before the first frame update

    void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.LoadCharacterData();

        money = gameManager.gameData.characters[gameManager.currentCharacterIndex].money;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
