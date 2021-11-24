using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallMoney : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float minTorque = -30;
    [SerializeField] float maxTorque = 30;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddTorque(Random.Range(minTorque, maxTorque));
    }

    
    void Update()
    {
        
    }
}
