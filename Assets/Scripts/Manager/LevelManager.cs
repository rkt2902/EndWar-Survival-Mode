using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public CharacterData characterData; // Referência ao CharacterData
    public GameObject imagePrefab;
    public Transform towerContainer;
    private GameManager gameManager;
    public SetTower setscr;

    private void Start()
    {
        gameManager = GameManager.Instance;
        characterData = gameManager.gameData.characters[gameManager.currentCharacterIndex];
        SpawnTowerImages();
    }

    private void SpawnTowerImages()
    {
        foreach (TowerData tower in characterData.selectedTowers)
        {
            // Crie um objeto vazio para conter a imagem da torre
            GameObject towerImageObject = Instantiate(imagePrefab, towerContainer);

            Image towerImage = towerImageObject.transform.Find("Image").GetComponent<Image>();

            towerImage.sprite = tower.TowerImage;

            TextMeshProUGUI Preco = towerImageObject.transform.Find("preco").GetComponent<TextMeshProUGUI>();
            Preco.text = tower.price.ToString();
            

            // Adicione um componente Button ao objeto da imagem
            Button buttonComponent = towerImage.GetComponent<Button>();

            // Adicione um listener ao botão para a ação de selecionar a torre
            buttonComponent.onClick.AddListener(() => SelectTower(tower));
        }
    }

    private void SelectTower(TowerData tower)
    {



        setscr.Selected = tower.id;


    }
}  