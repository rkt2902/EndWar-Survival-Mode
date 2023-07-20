using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float Cooldown;
    private float cd;
    private float originalCooldown;
    public GameObject Projectile;
    public bool hasEnemy;
    public bool shoots;
    
    // Start is called before the first frame update
    void Start()
    {
        cd = Cooldown;
        originalCooldown = Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }

        bool foundEnemy = false; // Flag to track if an enemy is found in any raycast

        RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.back, 15);
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                foundEnemy = true;
                break;
            }
            else if (hit.transform.CompareTag("Tower"))
            {
                Shoot towerShoot = hit.transform.gameObject.GetComponent<Shoot>();
                if (towerShoot.hasEnemy)
                {
                    foundEnemy = true;
                    break;
                }
            }
        }

        if (foundEnemy)
        {
            if (cd <= 0)
            {
                cd = Cooldown;
                if(shoots)
                {
                    GameObject projectileObj = Instantiate(Projectile, transform.position, Quaternion.identity);

                    Projetil projectile = projectileObj.GetComponent<Projetil>();

                    // Get the tower's damage value from the TowerData component
                    TowerData towerData = GetComponentInParent<TowerData>();
                    float towerDamage = towerData.Damage;

                    // Set the damage value of the projectile
                    projectile.Damage = towerDamage;
                }
                
            }
            hasEnemy = true;
        }
        else
        {
            hasEnemy = false;
        }
    }

    public void ReduceCooldown(float reductionPercentage)
    {
        Cooldown -= Cooldown * reductionPercentage;
    }
    public void ResetCooldown(float newCooldown)
    {
        Cooldown = newCooldown; // Restaura o cooldown original
    }
}
