using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Boxgenerator : MonoBehaviour
{
    [SerializeField] GameObject[] m_gameobject = default;//プレハブを入れておく配列
    [SerializeField] Transform[] m_transform = default;
    [SerializeField] BoxNumber[] bn = new BoxNumber[4];
    [SerializeField] int m_reduceMoney = 1000;
    [SerializeField] public float stageChange = 1f;
    int[] m_box = new int[]{0, 1, 2, 3};
    int[] m_shuffle = new int[4];
    float m_time;

    public int count;
    public int answerCount;
    void Start()
    {
        Generator();
    }

    void Update()
    {
        m_time += Time.deltaTime;
    }

    void Generator()
    {
        m_shuffle = m_box.ToList().OrderBy(i => Guid.NewGuid()).ToArray();
        for (int i = 0; i < m_gameobject.Length; i++)
        {
            bn[i].m_gameObject = Instantiate(m_gameobject[m_shuffle[i]],m_transform[i]);
        }
        if(m_time > 5f)
        {
            for(int i = 0; i < m_gameobject.Length; i++)
            {
                Destroy(m_gameobject[i]);
            }
        }
    }

}
