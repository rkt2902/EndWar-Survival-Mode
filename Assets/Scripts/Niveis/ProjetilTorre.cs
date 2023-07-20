using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilTorre : MonoBehaviour
{
    public float speed = 5f;
    public float Damage;
    private Transform target;

    public void SetTarget(Transform enemyTransform)
    {
        target = enemyTransform;
    }

    private void Update()
    {
       if (target == null)
        {
            // The target is destroyed, destroy the projectile
            Destroy(gameObject);
            return;
        }

        // Calculate the direction towards the target
        Vector3 direction = target.position - transform.position;

        // Normalize the direction to get a consistent speed
        direction.Normalize();

        // Move the projectile towards the target
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<Health>().health -= Damage;
           
            Destroy(gameObject);
       

        }
    }
}
