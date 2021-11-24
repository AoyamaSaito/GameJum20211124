using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene遷移の汎用スクリプト
/// </summary>
public class SceneChange : MonoBehaviour
{
    public void SceneChanger(string scene)
    {
        SceneManager.LoadScene(scene); 
    }
}
