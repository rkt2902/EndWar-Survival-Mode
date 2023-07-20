using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class CharacterData
{
    public string characterName;
    public int currentLevel;
    public int money;
    public float health;
    public int maxSlots;
    public List<TowerData> purchasedTowers;
    public List<TowerData> selectedTowers;
    public List<TowerProgress> towerProgresses;



    // Adicione outras estatísticas relevantes para o personagem

    // Construtor para inicializar os valores padrão do personagem
    public CharacterData(string name)
    {
        characterName = name;
        currentLevel = 1;
        money = 0;
        health = 10;
        maxSlots = 3; 
        purchasedTowers = new List<TowerData>();
        selectedTowers = new List<TowerData>();
        towerProgresses = new List<TowerProgress>();
        // Inicialize outras estatísticas padrão
    }
    public void AddTowerProgress(int towerID, int level)
    {
        // Verifique se o progresso para a torre já existe e atualize-o, caso contrário, adicione um novo progresso
        TowerProgress progress = towerProgresses.Find(p => p.towerID == towerID);
        if (progress != null)
        {
            progress.towerLevel = level;
        }
        else
        {
            towerProgresses.Add(new TowerProgress(towerID, level));
        }
    }

    public int GetTowerLevel(int towerID)
    {
        TowerProgress progress = towerProgresses.Find(p => p.towerID == towerID);
        if (progress != null)
        {
            return progress.towerLevel;
        }
        return 0;
    }

    public void IncreaseTowerLevel(int towerID)
    {
        TowerProgress progress = towerProgresses.Find(p => p.towerID == towerID);

        progress.towerLevel++;
    }



}


[System.Serializable]
public class TowerProgress
{
    public int towerID;
    public int towerLevel;
    

    public TowerProgress(int id, int level)
    {
        towerID = id;
        towerLevel = level;
       
    }
}



[System.Serializable]
public class GameData
{
    public List<CharacterData> characters;
    public List<TowerData> towers;


    // Construtor para inicializar a lista de personagens
    public GameData()
    {
        characters = new List<CharacterData>();
        towers = new List<TowerData>();
    }
}



