using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float movementSpeed;
    public bool canmove;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canmove)
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }

       


    }
    public void DecreaseMovementSpeed(float reductionPercentage)
    {
        movementSpeed -= movementSpeed * reductionPercentage;
    }

}
