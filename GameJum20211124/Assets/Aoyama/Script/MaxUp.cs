using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxUp : MonoBehaviour
{
    [SerializeField] int[] goals = new int[5];
    [SerializeField] int[] nextmaxMoneys = new int[5];
    [SerializeField] int currentGoalIndex = 0;
    [SerializeField] int nextMaxIndex = 0;
    [SerializeField] GameObject missText = default;
    [SerializeField] float missTextTime = 1f;
    Text goalText;
    Button maxUpButton = default;

    public static MaxUp Instance = default;

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
    int goal = 0;

    int nextMaxMoney = 0;

    void Start()
    {
        goalText = GameObject.Find("MaxUpGoalText").GetComponent<Text>();
        maxUpButton = GameObject.Find("MaxUpButton").GetComponent<Button>();
        goal = goals[currentGoalIndex++];
        nextMaxMoney = nextmaxMoneys[nextMaxIndex++];
        goalText.text = "上限アップ額:" + goal.ToString();
    }

    private void Update()
    {
        if (goalText == null && GameObject.Find("MaxUpGoalText") != null)
        {
            goalText = GameObject.Find("MaxUpGoalText").GetComponent<Text>();
            maxUpButton = GameObject.Find("MaxUpButton").GetComponent<Button>();
            maxUpButton.onClick.AddListener(() => Buy());
        }

        goalText.text = "上限アップ額:" + goal.ToString();
    }

    public void Buy()
    {
        if (MoneyManager.CurrentMoney >= goal)
        {
            MoneyManager.UpMaxMoney(nextMaxMoney);
            MoneyManager.ReduceMoney(goal);
            goal = goals[currentGoalIndex++];
            nextMaxMoney = nextmaxMoneys[nextMaxIndex++];
            goalText.text = "上限アップ額:" + goal.ToString();
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
