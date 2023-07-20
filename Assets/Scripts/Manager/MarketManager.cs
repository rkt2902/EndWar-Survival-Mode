using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    public CharacterData characterData; // Refer�ncia ao CharacterData para armazenar as torres compradas
    public GameObject towerButtonPrefab; // Prefab do bot�o de compra da torre
    public Transform towerButtonContainer; // Container para os bot�es de compra
    private GameManager gameManager;
    private List<TowerData> selectedTowerButtons;

    private string paragraph= "\n";


    private void Start()
    {
        
        gameManager = GameManager.Instance;
        gameManager.LoadCharacterData();
        characterData = gameManager.gameData.characters[gameManager.currentCharacterIndex];
        selectedTowerButtons = gameManager.gameData.characters[gameManager.currentCharacterIndex].selectedTowers;
        // Cria os bot�es de compra para as torres dispon�veis
        CreateTowerButtons();
    }

    private void CreateTowerButtons()
    {
        
        foreach (TowerData tower in gameManager.gameData.towers)
        {
          
            string towername = tower.name;
           bool isTowerPurchased = gameManager.IsTowerPurchased(towername);

            // Instantiate the tower button prefab
            GameObject towerButtonObject = Instantiate(towerButtonPrefab, towerButtonContainer);

            Image towerImage = towerButtonObject.transform.Find("TowerImage").GetComponent<Image>();
            towerImage.sprite = tower.TowerImage;


            towerButtonObject.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = tower.towername;


            Button Select = towerButtonObject.transform.Find("Uso").GetComponent<Button>();
            Button Compra = towerButtonObject.transform.Find("Compra").GetComponent<Button>();
           
            Select.onClick.AddListener(() => UseTower(tower, Select));

            Select.enabled = false;
            Select.GetComponentInChildren<TextMeshProUGUI>().text = "Usar";

            TextMeshProUGUI Pre�o = towerButtonObject.transform.Find("Price").GetComponent<TextMeshProUGUI>();

            // Adiciona um listener ao bot�o para a a��o de compra
          
            if (isTowerPurchased)
            {

                Select.enabled = true;

                Compra.onClick.RemoveAllListeners();
                Compra.GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade";
                Pre�o.text = "Pre�o Upgrade: " + UpgradePrice(tower);
                Compra.onClick.AddListener(() => UpgradeTower(tower));
            }
            else
            {
                 Compra.GetComponentInChildren<TextMeshProUGUI>().text = "Buy";
                 Pre�o.text = "Pre�o: " + tower.price.ToString();
                Compra.onClick.AddListener(() => BuyTower(tower));


                

            }

        }
    }
    private void BuyTower(TowerData tower)
    {
        if (characterData.purchasedTowers.Contains(tower))
        {
            // Tower is already purchased, perform upgrade instead
            UpgradeTower(tower);
            return;
        }

        // Verifica se o jogador possui dinheiro suficiente para comprar a torre
        if (characterData.money >= tower.price) {

            // Deduz o pre�o da torre do dinheiro do jogador
            characterData.money -= tower.price;

            // Adiciona a torre � lista de torres compradas no CharacterData
            

            characterData.purchasedTowers.Add(tower);

            characterData.AddTowerProgress(tower.id, tower.level);

            UpdateTowerButton(tower);

            UnityEngine.Debug.Log("Torre comprada: " + tower.name);

           
            // Atualiza os dados do CharacterData (salve-os se necess�rio)
             gameManager.SaveCharacterData();
        }
        else
        {
            UnityEngine.Debug.Log("Dinheiro insuficiente para comprar a torre: " + tower.name);
        }
    }

    private void UpgradeTower (TowerData tower)
    {


        if(characterData.GetTowerLevel(tower.id) < 5)
        {
            if (characterData.money >= UpgradePrice(tower))
            {

                // Deduz o pre�o da torre do dinheiro do jogador
                characterData.money -= UpgradePrice(tower);
                characterData.IncreaseTowerLevel(tower.id);
                
                UpdateTowerButton(tower);
            //    gameManager.UpgradeTowerLevel(tower); 
                UnityEngine.Debug.Log("Torre Upgrade: " + tower.name);


                // Atualiza os dados do CharacterData (salve-os se necess�rio)
                  gameManager.SaveCharacterData();
            }


        }
       
    }


    private int UpgradePrice(TowerData tower)
    {
        return tower.upgrades[characterData.GetTowerLevel(tower.id) - 1];

    }

    private void UpdateTowerButton(TowerData tower)
    {

        // Find the corresponding tower button in the tower button container
        int index = gameManager.gameData.towers.IndexOf(tower);
        if (index >= 0 && index < towerButtonContainer.childCount)
        {
            GameObject towerButton = towerButtonContainer.GetChild(index).gameObject;
            Button Select = towerButton.transform.Find("Uso").GetComponent<Button>();
            
            // Get the button component from the tower button
            Button Compra = towerButton.transform.Find("Compra").GetComponent<Button>();

            TextMeshProUGUI Pre�o = towerButton.transform.Find("Price").GetComponent<TextMeshProUGUI>();

            Select.enabled = true;

            if (characterData.purchasedTowers.Contains(tower))
            {
                // Tower is purchased, update button text and function for upgrade
                Compra.GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade";
                Pre�o.text = "Pre�o Upgrade: " + UpgradePrice(tower);
                Compra.onClick.RemoveAllListeners();
                Compra.onClick.AddListener(() => UpgradeTower(tower));
            }
        }
    }

    private void UseTower(TowerData tower, Button btnapp)
    {
        string towername = tower.name;
        bool isTowerPurchased = gameManager.IsTowerPurchased(towername);
        // Verifica se a torre j� est� selecionada
        if (selectedTowerButtons.Contains(tower))
        {
            // Remove a torre da lista de torres selecionadas
            selectedTowerButtons.Remove(tower);

            Debug.Log("Torre removida da lista de torres selecionadas: " + tower.name);

            // Atualiza a apar�ncia do bot�o (por exemplo, desativa algum indicador visual de sele��o)
           btnapp.GetComponentInChildren<TextMeshProUGUI>().text = "Usar";
        }
        else
        {
           if (isTowerPurchased)
           {
                // Verifica se o n�mero m�ximo de torres selecionadas foi atingido
                if (selectedTowerButtons.Count < characterData.maxSlots)
            {
                // Adiciona a torre � lista de torres selecionadas
                selectedTowerButtons.Add(tower);

                Debug.Log("Torre adicionada � lista de torres selecionadas: " + tower.name);

                // Atualiza a apar�ncia do bot�o (por exemplo, ativa algum indicador visual de sele��o)
                btnapp.GetComponentInChildren<TextMeshProUGUI>().text = "Selected";
                
            }
            else
            {
                Debug.Log("N�mero m�ximo de torres selecionadas atingido");
            }
            }
            else
            {
                Debug.Log("Torre n�o dispon�vel para sele��o: " + tower.name);
            }
        }
    }
}



