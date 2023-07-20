using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    public bool isTower;
    public bool explodes;
    public int enemyValue;
    private Health hscr;
    private Money mscr;
    public float explosionRadius;
    public int explosionDamage;

    // Start is called before the first frame update
    void Start()
    {
       hscr = GetComponent<Health>();
        mscr = GameObject.Find("GameLogic").GetComponent<Money>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hscr.health <= 0)
        {
            if(isTower)
            {
                Destroy(gameObject);
                if(explodes)
                {
                    explosion();
                }
            }
            else if(explodes){

                explosion();
                mscr.money += enemyValue;
            }
            else
            {
                //MORTE DO INIMIGO
                mscr.money += enemyValue;
                Destroy(gameObject);


            }
        }
    }


    private void explosion()
    {
     

        // Causar dano em área 
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in colliders)
        {
            if (isTower)
            {
                if (col.CompareTag("Enemy"))
                {
                    col.GetComponent<Health>().health -= explosionDamage;
                }
            }
            else
            {
                if (col.CompareTag("Tower"))
                {
                    col.GetComponent<Health>().health -= explosionDamage;
                }
            }
            

        }

        // Destruir o objeto zombie
        Destroy(gameObject);
    }
}
