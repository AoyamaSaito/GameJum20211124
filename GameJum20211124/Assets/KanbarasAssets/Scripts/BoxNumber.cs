using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoxNumber : MonoBehaviour
{
    public GameObject m_gameObject = default;
    Boxgenerator bg;

    public void Judge()
    {
        bg = GameObject.Find("Generator").GetComponent<Boxgenerator>();
        bg.mm = GameObject.Find("GameManager").GetComponent<MoneyManager>();
        bg.count++;
        Debug.Log($"Box{bg.count}");
        Debug.Log(m_gameObject.name);

        if(m_gameObject.name == $"Box{bg.count}(Clone)")
        {
            bg.answerCount++;
            Debug.Log(bg.answerCount);
        }
        else
        {
            MoneyManager.ReduceMoney(MoneyManager.CurrentMoney/10);
            StartCoroutine(StageChange());
        }

        if(bg.answerCount == 4)
        {
            bg.mm.AddMoney(MoneyManager.CurrentMoney / 10);
            StartCoroutine(StageChange());
        }
    }

    IEnumerator StageChange()
    {
        yield return new WaitForSeconds(bg.stageChange);
        SceneManager.LoadSceneAsync("MainScene");//シーンの名前を入れる
    }
}
