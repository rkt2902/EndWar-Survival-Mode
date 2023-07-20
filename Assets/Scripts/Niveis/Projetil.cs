using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float MovementSpeed;
    public float Damage;
    public Vector3 initpos;
    public GameObject explosion;
    public bool IsSniper;

    private int ncol = 0;

    // Start is called before the first frame update
    void Start()
    {
        initpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * MovementSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, initpos) > 20)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<Health>().health -= Damage;
            if (IsSniper)
            {
                Damage = Damage * 0.5f;
                ncol++;

                if(ncol >= 4)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
                
        }
    }
}
