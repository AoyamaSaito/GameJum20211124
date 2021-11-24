using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Boxgenerator : MonoBehaviour
{
    [SerializeField] GameObject[] m_gameobject = default;
    int[] m_box = new int[]{0, 1, 2, 3};
    int[] m_shuffle = new int[4];

    void Start()
    {
        Generator();
    }

    void Update()
    {
        
    }

    void Generator()
    {
        m_shuffle = m_box.ToList().OrderBy(i => Guid.NewGuid()).ToArray();
        for (int i = 0; i < m_gameobject.Length; i++)
        {
            GameObject go = Instantiate(m_gameobject[m_shuffle[i]]);
        }
    }
}
