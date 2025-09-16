using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region 单例
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [Header("游戏配置")]
    public GameObject Panel;
    public GameObject table;         // 拼图容器
    public GameObject winPanel;      // 胜利面板
    public Button restartButton;     // 重新开始按钮

    private int[] currentArray;      // 当前拼图状态
    private readonly int[] solvedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }; // 完成状态

    void Start()
    {
        winPanel.SetActive(false);
        restartButton.onClick.AddListener(GameStart);
        GameStart();
    }

    /// <summary> 开始新游戏 </summary>
    public void GameStart()
    {
        winPanel.SetActive(false);
        InitializePuzzle();
        ShuffleArray(50); // 充分打乱
        UpdatePuzzleDisplay();
    }

    /// <summary> 初始化拼图数组 </summary>
    void InitializePuzzle()
    {
        currentArray = (int[])solvedArray.Clone();
    }

    /// <summary> Fisher-Yates洗牌算法 </summary>
    void ShuffleArray(int shuffleTimes)
    {
        for (int i = 0; i < shuffleTimes; i++)
        {
            int r1 = Random.Range(0, currentArray.Length);
            int r2 = Random.Range(0, currentArray.Length);
            (currentArray[r1], currentArray[r2]) = (currentArray[r2], currentArray[r1]);
        }
    }

    /// <summary> 更新拼图显示 </summary>
    void UpdatePuzzleDisplay()
    {
        for (int i = 0; i < currentArray.Length; i++)
        {
            Transform piece = table.transform.Find($"piece{currentArray[i]}");
            piece.SetSiblingIndex(i);
        }
    }

    /// <summary> 图块点击事件 </summary>
    public void OnPieceClick(int number)
    {
        if (number == 16) return; // 空白块不可点击

        int clickedIndex = GetPieceIndex(number);
        int blankIndex = GetBlankIndex();

        if (IsValidMove(clickedIndex, blankIndex))
        {
            SwapPieces(clickedIndex, blankIndex);
            CheckWinCondition();
        }
    }

    /// <summary> 获取图块索引 </summary>
    int GetPieceIndex(int number)
    {
        for (int i = 0; i < currentArray.Length; i++)
            if (currentArray[i] == number) return i;
        return -1;
    }

    /// <summary> 获取空白块索引 </summary>
    int GetBlankIndex()
    {
        return GetPieceIndex(16);
    }

    /// <summary> 验证移动有效性 </summary>
    bool IsValidMove(int clicked, int blank)
    {
        // 同一行相邻或同一列相邻
        return (Mathf.Abs(clicked - blank) == 1 && clicked / 4 == blank / 4) ||
               Mathf.Abs(clicked - blank) == 4;
    }

    /// <summary> 交换拼图位置 </summary>
    void SwapPieces(int indexA, int indexB)
    {
        (currentArray[indexA], currentArray[indexB]) = (currentArray[indexB], currentArray[indexA]);
        UpdatePuzzleDisplay();
    }

    /// <summary> 检查胜利条件 </summary>
    void CheckWinCondition()
    {
        for (int i = 0; i < solvedArray.Length; i++)
        {
            if (currentArray[i] != solvedArray[i]) return;
        }
        Panel.SetActive(false);
        winPanel.SetActive(true);
    }
}