using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    private EnemyMove movscr;
    public float Damage;
    public float Cooldown;
    private float cd;
    // Start is called before the first frame update
    void Start()
    {
        movscr = gameObject.GetComponent<EnemyMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cd > 0)
        {
            cd -= Time.deltaTime;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 0.5f))
        {
            if (hit.transform.CompareTag("Tower"))
            {
                if(cd <= 0)
                {
                    Health hscr = hit.transform.GetComponent<Health>();
                    hscr.health -= Damage;
                    cd = Cooldown;
                }
                
            }
         //   else if (hit.transform.CompareTag("house"))
           // {
                //lose
           // }
            movscr.canmove = false;
        }
        else if (movscr.canmove == false)
        {
            movscr.canmove = true;
        }
    }
}
