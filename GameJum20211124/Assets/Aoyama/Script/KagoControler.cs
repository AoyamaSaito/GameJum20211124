using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KagoControler : MonoBehaviour
{
    [SerializeField, Tooltip("動くスピード")] float moveSpeed = 5f;
    MoneyManager moneyManager = default;
    [SerializeField] int addMoney = 0;
    [SerializeField] AudioClip moneySE = default;
    //[SerializeField] UnityEvent AddMoney;

    float h = 0;
    Rigidbody2D rb;
    AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moneyManager = GameObject.Find("GameManager").GetComponent<MoneyManager>() ;
        rb.gravityScale = 0;
        audioSource = this.gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        if (moneyManager == null)
        {
            moneyManager = GameObject.Find("GameManager").GetComponent<MoneyManager>();
        }   
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
            moneyManager.AddMoney(addMoney);
            audioSource.PlayOneShot(moneySE);
        }
    }
}
