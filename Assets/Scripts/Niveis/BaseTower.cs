using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public Vector3 range = new Vector3(10f, 2f, 5f);

    public float Cooldown;
    private float cd;
    private float originalCooldown;

    // Start is called before the first frame update
    void Start()
    {
        cd = Cooldown;
        originalCooldown = Cooldown;
    }

    private void Update()
    {
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }
        if (cd <= 0 && TargetIsInRange())
        {
            cd = Cooldown;
            Shoot();

        }

    }

    private bool TargetIsInRange()
    {
        Collider[] colliders = Physics.OverlapBox(firePoint.position, range / 2f, Quaternion.identity);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                return true;
            }
        }

        return false;
    }

    private void Shoot()
    {
        Collider[] colliders = Physics.OverlapBox(firePoint.position, range / 2f, Quaternion.identity);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Transform target = collider.transform;
                GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                ProjetilTorre projectileComponent = projectile.GetComponent<ProjetilTorre>();
                if (projectileComponent != null)
                {
                    projectileComponent.SetTarget(target);
                    break;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(firePoint.position, range);
    }
}

