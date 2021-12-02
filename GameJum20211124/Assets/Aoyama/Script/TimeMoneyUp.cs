using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeMoneyUp : MonoBehaviour
{
    [SerializeField] int[] goals = new int[5];
    [SerializeField] int currentGoalIndex = 0;
    //[SerializeField] GameObject missText = default;
    [SerializeField] float missTextTime = 1f;
    Text goalText;
    [SerializeField] int addMoney = 10;
    Button upButton = default;

    public static TimeMoneyUp Instance = default;

    int goal = 0;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        goalText = GameObject.Find("TimeGoalText").GetComponent<Text>();
        upButton = GameObject.Find("TimeMoneyUpButton").GetComponent<Button>();
        goal = goals[currentGoalIndex++];
        goalText.text = "獲得量アップ額:" + goal.ToString();
    }

    private void Update()
    {
        if (goalText == null && GameObject.Find("TimeGoalText") != null)
        {
            goalText = GameObject.Find("TimeGoalText").GetComponent<Text>();
            upButton = GameObject.Find("TimeMoneyUpButton").GetComponent<Button>();
            upButton.onClick.AddListener(() => Buy());
        }

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
        TheGoal.missText.SetActive(true);
        yield return new WaitForSeconds(missTextTime);
        TheGoal.missText.SetActive(false);
    }
}
