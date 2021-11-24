using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxNumber : MonoBehaviour
{
    public GameObject m_gameObject = default;
    Boxgenerator bg;

    private void Start()
    {
     
    }

    public void Judge()
    {
        bg = GameObject.Find("Generator").GetComponent<Boxgenerator>();
        bg.count++;
        Debug.Log($"Box{bg.count}");

        if(m_gameObject.name == $"Box{bg.count}")
        {
            bg.answerCount++;
            Debug.Log(bg.answerCount);
        }
        else
        {
            //miss
        }

        if(bg.answerCount == 4)
        {
            //clear
        }
    }
}
