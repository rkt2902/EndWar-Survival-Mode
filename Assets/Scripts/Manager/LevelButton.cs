using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.VersionControl;

public class LevelButton : MonoBehaviour
{
    public int characterIndex; // Índice do personagem na lista de GameData
    public GameManager gameManager;



    public void Start()
    {
        gameManager = GameManager.Instance;

        Button button = GetComponent<Button>();
        button.onClick.AddListener(ChangeScene);
    }

    public void ChangeScene()
    {   
        


       gameManager.SaveCharacterData();
        gameManager.StartGame();
    }

    
}
