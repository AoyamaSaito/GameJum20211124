using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGenerator : MonoBehaviour
{
    [SerializeField] GameObject Money;
    [SerializeField] float minInterval = 5f;
    [SerializeField] float maxInterval = 8f;

    float interval = 0;
    float timer = 0;
    void Start()
    {
        interval = Random.Range(minInterval, maxInterval);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            Instantiate(Money, gameObject.transform.position, Quaternion.identity);
            timer = 0;
            interval = Random.Range(minInterval, maxInterval);
        }
    }
}
