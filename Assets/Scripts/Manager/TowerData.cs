
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerData : MonoBehaviour
{
    public int id;
    public string towername;
    public int price;
    public int level;
    public float baseHealth;
    public float baseDamage;
    public int[] upgrades;

    public Sprite TowerImage
    {
        get
        {
            return Resources.Load<Sprite>(name);
        }
    }

    public float Health
    {
        get { return baseHealth * Mathf.Pow(1.25f, level - 1); }
    }

    public float Damage
    {
        get { return baseDamage * Mathf.Pow(1.25f, level - 1); }
    }

}




