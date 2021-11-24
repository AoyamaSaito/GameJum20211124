using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheGoal : MonoBehaviour
{
    [SerializeField] int[] goals = new int[5];
    [SerializeField] int currentGoalIndex = 0;
    [SerializeField] GameObject missText = default;
    [SerializeField] float missTextTime = 1f;
    [SerializeField] Text goalText;

    int goal = 0;

    void Start()
    {
        goal = goals[currentGoalIndex++];
        goalText.text = goal.ToString();
    }

    public void Buy()
    {
        if(MoneyManager.CurrentMoney >= goal)
        {
            MoneyManager.ReduceMoney(goal);
            goal = goals[currentGoalIndex++];
            goalText.text = goal.ToString();
        }
        else
        {
            StartCoroutine(MissText());
        }
    }

    IEnumerator MissText()
    {
        missText.SetActive(true);
        yield return new WaitForSeconds(missTextTime);
        missText.SetActive(false);
    }
}
