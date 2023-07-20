using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using System.Linq;


public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public int currentCharacterIndex;
    public static GameManager Instance;

    private void Start()
    {
        // Inicialize os dados do jogo (carregue de um arquivo de salvamento ou defina valores padrão)
      //  gameData = new GameData();
        // Adicione os personagens disponíveis ao gameData
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public CharacterData GetCurrentCharacter()
    {
        return gameData.characters[currentCharacterIndex];
    }

  /*  public void SelectNextCharacter()
    {
        // Avance para o próximo personagem na lista circularmente
        currentCharacterIndex = (currentCharacterIndex + 1) % gameData.characters.Count;
    }
  */

    public void GoMarket()
    {
        // Inicie o jogo com o personagem atual
        CharacterData currentCharacter = GetCurrentCharacter();

        PlayerPrefs.SetInt("SelectedCharacterIndex", currentCharacterIndex);
        



        PlayerPrefs.Save();
        SceneManager.LoadScene("Market");
        // Carregue o nível inicial ou execute outras ações de inicialização do jogo
    }

    public void StartGame()
    {
        CharacterData currentCharacter = GetCurrentCharacter();

        SaveCharacterData();
        PlayerPrefs.SetInt("SelectedCharacterIndex", currentCharacterIndex);
        Debug.Log("Iniciando o jogo com o personagem: " + currentCharacter.characterName);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level");
    }

    public void LevelCompleted()
    {
        // Atualize o progresso do personagem atual
        CharacterData currentCharacter = GetCurrentCharacter();
        currentCharacter.currentLevel++;
        // Aumente a dificuldade do jogo (por exemplo, aumente o dano dos inimigos)
        // Faça outras atualizações relevantes após a conclusão do nível
    }

    public void SaveCharacterData()
    {
        CharacterData currentCharacter = GetCurrentCharacter();
        // Converte o objeto CharacterData para formato JSON
        string jsonData = JsonUtility.ToJson(currentCharacter);
        
        // Salva os dados do personagem no PlayerPrefs
        PlayerPrefs.SetString("Data"+currentCharacter.characterName, jsonData);

        // Salva os dados no PlayerPrefs
        PlayerPrefs.Save();
        
        Debug.Log("Dados do personagem salvos com sucesso!");
    }


    public void LoadCharacterData()
    {
        CharacterData currentCharacter = GetCurrentCharacter();
        // Retrieve the JSON data from PlayerPrefs using the same unique key
        string jsonData = PlayerPrefs.GetString("Data" + currentCharacter.characterName);

        // Check if the JSON data exists
        if (!string.IsNullOrEmpty(jsonData))
        {
            // Convert the JSON data back to a CharacterData object
            CharacterData savedCharacterData = JsonUtility.FromJson<CharacterData>(jsonData);

            // Update the current character's data with the saved data
            currentCharacter.currentLevel = savedCharacterData.currentLevel;
            currentCharacter.money = savedCharacterData.money;
            currentCharacter.health = savedCharacterData.health;
            currentCharacter.maxSlots = savedCharacterData.maxSlots;
            currentCharacter.purchasedTowers = savedCharacterData.purchasedTowers;
            currentCharacter.towerProgresses = savedCharacterData.towerProgresses;
            

            // Update any other relevant character data fields

            Debug.Log("Character data loaded successfully!");
        }
        else
        {
            Debug.Log("No saved character data found.");
        }
    }


    public bool IsTowerPurchased(string towername)
    {


        CharacterData currentCharacter = GetCurrentCharacter();

        return currentCharacter.purchasedTowers.Any(tower => tower.name == towername);


    }

    public void UpgradeTowerLevel(TowerData tower)
    {

        CharacterData currentCharacter = GetCurrentCharacter();
        // Procura a torre na lista de torres compradas pelo seu nome
        TowerData purchasedTower = currentCharacter.purchasedTowers.Find(t => t.name == tower.name);

        if (purchasedTower != null)
        {
            purchasedTower.level = tower.level;
        }
    }

}
