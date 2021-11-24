using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeMoneyUp : MonoBehaviour
{
    [SerializeField] int[] goals = new int[5];
    [SerializeField] int currentGoalIndex = 0;
    [SerializeField] GameObject missText = default;
    [SerializeField] float missTextTime = 1f;
    [SerializeField] Text goalText;
    [SerializeField] int addMoney = 10;

    int goal = 0;

    void Start()
    {
        goal = goals[currentGoalIndex++];
        goalText.text = "獲得量アップ額:" + goal.ToString();
    }

    public void Buy()
    {
        if (MoneyManager.CurrentMoney >= goal)
        {
            MoneyManager.addTimeMoeny(addMoney);
            MoneyManager.ReduceMoney(goal);
            goal = goals[currentGoalIndex++];
            goalText.text = "獲得量アップ額:" + goal.ToString();
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
