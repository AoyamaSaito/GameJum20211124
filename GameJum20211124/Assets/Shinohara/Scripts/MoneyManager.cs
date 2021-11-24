using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyManager : MonoBehaviour
{
    [Tooltip("テスト用所持金")]
    [SerializeField] int _testMoney = 0;
    [Tooltip("テスト用上限")]
    [SerializeField] int _testMaxMoney = 0;
    [SerializeField] Text _text = default;
    [SerializeField] Text _maxText = default;

    /// <summary>時間経過で増える量</summary>
    [SerializeField] int _addMoneyAmount = 0;
    /// <summary>お金をが増える間隔</summary>
    [SerializeField] float _addMoneyInterval = 0f;
    /// <summary>現在の所持金</summary>
    static int _currentMoney = 0;
    /// <summary>所持金の上限</summary>
    static int _maxMoney = 0;
    
    /// <summary>インスタンスを取得するためのパブリック変数</summary>
    public static MoneyManager Instance = default;

    float _time = 0f;

    /// <summary>現在の所持金</summary>
    public static int CurrentMoney { get => _currentMoney; set => _currentMoney = value; }
    /// <summary>所持金の上限</summary>
    public static int MaxMoney { get => _maxMoney; set => _maxMoney = value; }

    // Start is called before the first frame update
    void Start()
    {
        _currentMoney = _testMoney;
        _maxMoney = _testMaxMoney;
        Debug.Log($"所持金 {_currentMoney}");
        Debug.Log($"上限　{_maxMoney}");
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        _text.text = "所持金" + _currentMoney.ToString();
        _maxText.text = "上限" + _maxMoney.ToString();
        TimeMoney();
        
    }

    /// <summary>お金を増やす</summary>
    /// <param name="addmoney">増やす量</param>
    public static void AddMoney(int addMoney)
    {
        Debug.Log("上がる");
        _currentMoney = Mathf.Min(_currentMoney  + addMoney, _maxMoney);
    }

    /// <summary>お金を減らす</summary>
    /// <param name="reduceMoney">減らす量</param>
    public static void ReduceMoney(int reduceMoney)
    {
        Debug.Log("下がる");
        _currentMoney = Mathf.Max(_currentMoney - reduceMoney, 0);
    }

    /// <summary>上限を上げる</summary>
    /// <param name="nextMaxMoney">次の上限</param>
    public static void UpMaxMoney(int nextMaxMoney)
    {
        Debug.Log("上限を上げる");
        _maxMoney = nextMaxMoney;
    }

    /// <summary>時間経過で増えるお金</summary>
    private void TimeMoney()
    {
        if (_time >= _addMoneyInterval && _currentMoney < _maxMoney)
        {
            Debug.Log($"所持金 {_currentMoney}");
            _currentMoney += _addMoneyAmount;
            _time = 0f;
        }
        else if (_time >= _addMoneyInterval)
        {
            Debug.Log($"所持金上限");
            _time = 0f;
        }
    }
}
