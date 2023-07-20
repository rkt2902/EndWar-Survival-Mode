using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public CharacterData characterData; 
    public float health;
    public bool isbase;
    [SerializeField] Healthbar _healthbar;
    private GameManager gameManager;
    private TowerData towerData;




    private void Start()
    {
        gameManager = GameManager.Instance;

        characterData = gameManager.GetCurrentCharacter();

        if (isbase)
        {
            health = characterData.health;
            _healthbar.SetMaxHealth((int)health);
        }
    }



    void Update()
    {
        if (isbase)
        {
            _healthbar.SetHealth(((int)health));
        }
        
    }

    public void SetTowerData(TowerData data)
    {
        towerData = data;
        health = towerData.Health;
    }

    public void BoostHealth(float boostPercentage)
    {
        health += health * boostPercentage;
    }
}
