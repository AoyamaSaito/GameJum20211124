using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KagoControler : MonoBehaviour
{
    [SerializeField, Tooltip("動くスピード")] float moveSpeed = 5f;
    [SerializeField] UnityEvent AddMoney;

    float h = 0;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(h * moveSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Money"))
        {
            Destroy(collision.gameObject);
            AddMoney.Invoke();
        }
    }
}
