using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGoal : MonoBehaviour
{
    [SerializeField] int[] goals;
    [SerializeField] int currentGoal = 0;

    int goal = 0;
    void Start()
    {
        goal = goals[currentGoal];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Buy()
    {
        //if()
    }
}
