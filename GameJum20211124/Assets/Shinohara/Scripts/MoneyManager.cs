using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyManager : MonoBehaviour
{
    [Tooltip("テスト用所持金")]
    [SerializeField] int _testMoney = 0;
    [Tooltip("最初の上限")]
    [SerializeField] int _firstMaxMoney = 0;
    /// <summary>時間経過で増える量</summary>
    [SerializeField] int _addMoneyAmount = 0;
    /// <summary>お金をが増える間隔</summary>
    [SerializeField] float _addMoneyInterval = 0f;

    /// <summary>現在の所持金</summary>
    static int _currentMoney = 0;
    /// <summary>所持金の上限</summary>
    static int _maxMoney = 0;

    static int _addAmount = 0;

    static float _addInterval = 0f;

    /// <summary>インスタンスを取得するためのパブリック変数</summary>
    public static MoneyManager Instance = default;

    static float _time = 0f;

    /// <summary>現在の所持金</summary>
    public static int CurrentMoney { get => _currentMoney; set => _currentMoney = value; }
    /// <summary>所持金の上限</summary>
    public static int MaxMoney { get => _maxMoney; set => _maxMoney = value; }

    /// <summary>シングルトン</summary>
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

    // Start is called before the first frame update
    void Start()
    {
        _currentMoney = _testMoney;
        _maxMoney = _firstMaxMoney; //最初の上限を設定する
        _addInterval = _addMoneyInterval;
        _addAmount = _addMoneyAmount;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        TimeMoney();
        
    }

    /// <summary>お金を増やす</summary>
    /// <param name="addmoney">増やす量</param>
    public static void AddMoney(int addMoney)
    {
        _currentMoney = Mathf.Min(_currentMoney  + addMoney, _maxMoney);
    }

    /// <summary>お金を減らす</summary>
    /// <param name="reduceMoney">減らす量</param>
    public static void ReduceMoney(int reduceMoney)
    {
        _currentMoney = Mathf.Max(_currentMoney - reduceMoney, 0);
    }

    /// <summary>上限を上げる</summary>
    /// <param name="nextMaxMoney">次の上限</param>
    public static void UpMaxMoney(int nextMaxMoney)
    {
        _maxMoney = nextMaxMoney;
    }

    /// <summary>時間経過で増えるお金</summary>
    private static void TimeMoney()
    {
        if (_time >= _addInterval && _currentMoney < _maxMoney)
        {
            _currentMoney += _addAmount;
            _time = 0f;
        }
        else if (_time >= _addInterval)
        {
            _time = 0f;
        }
    }
}
