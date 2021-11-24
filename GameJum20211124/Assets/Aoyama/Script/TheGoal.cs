using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheGoal : MonoBehaviour
{
    [SerializeField] int[] goals = new int[5];
    [SerializeField] int currentGoalIndex = 0;
    public static GameObject missText = default;
    [SerializeField] float missTextTime = 1f;
    Text goalText;

    public static TheGoal Instance = default;

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

   static int goal = 0;

    void Start()
    {
        goalText = GameObject.Find("GoalText").GetComponent<Text>();
        missText = GameObject.Find("NoMoney");
        goal = goals[currentGoalIndex++];
        goalText.text = goal.ToString();
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("GoalText") != null)
        {
            goalText = GameObject.FindGameObjectWithTag("GoalText").GetComponent<Text>();
        }

        if (missText == null)
        {
            missText = GameObject.Find("NoMoney");
        }


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
