using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyManager : MonoBehaviour
{
    [Tooltip("最初の上限")]
    [SerializeField] int _firstMaxMoney = 0;
    /// <summary>時間経過で増える量</summary>
    [SerializeField] int _addMoneyAmount = 0;
    /// <summary>現在の所持金</summary>
    [SerializeField] Text _moneyText = default;
    /// <summary>上限金額</summary>
    [SerializeField] Text _maxMoenyText = default;
    /// <summary>現在の所持金</summary>
    static int _currentMoney = 0;
    /// <summary>所持金の上限</summary>
    static int _maxMoney = 0;
    /// <summary>時間経過で増える量</summary>
    static int _addAmount = 0;
    /// <summary>インスタンスを取得するためのパブリック変数</summary>
    public static MoneyManager Instance = default;

    static float _time = 0f;

    /// <summary>現在の所持金</summary>
    public static int CurrentMoney { get => _currentMoney; set => _currentMoney = value; }
    /// <summary>所持金の上限</summary>
    public static int MaxMoney { get => _maxMoney; set => _maxMoney = value; }
    /// <summary>時間経過で増える量</summary>
    public static int AddAmount { get => _addAmount; set => _addAmount = value; }

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
        _maxMoney = _firstMaxMoney; //最初の上限を設定する
        _addAmount = _addMoneyAmount;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        _moneyText.text = "所持金"+ _currentMoney.ToString();
        _maxMoenyText.text = "上限金額" + _maxMoney.ToString();
         TimeMoney();
        _currentMoney = Mathf.Clamp(_currentMoney, 0, _maxMoney);
    }

    /// <summary>お金を増やす</summary>
    /// <param name="addmoney">増やす量</param>
    public void AddMoney(int addMoney)
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
    public static void TimeMoney()
    {
        
        if (_time >= 1f && _currentMoney < _maxMoney)
        {
            _currentMoney = Mathf.Min(_currentMoney + _addAmount, _maxMoney);
            _time = 0f;
        }
        else if (_time >= 1f)
        {
            _time = 0f;
        }
    }

    public static void addTimeMoeny(int addAmount)
    {
        _addAmount += addAmount;
    }
}
