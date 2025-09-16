using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region ����
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

    [Header("��Ϸ����")]
    public GameObject Panel;
    public GameObject table;         // ƴͼ����
    public GameObject winPanel;      // ʤ�����
    public Button restartButton;     // ���¿�ʼ��ť

    private int[] currentArray;      // ��ǰƴͼ״̬
    private readonly int[] solvedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }; // ���״̬

    void Start()
    {
        winPanel.SetActive(false);
        restartButton.onClick.AddListener(GameStart);
        GameStart();
    }

    /// <summary> ��ʼ����Ϸ </summary>
    public void GameStart()
    {
        winPanel.SetActive(false);
        InitializePuzzle();
        ShuffleArray(50); // ��ִ���
        UpdatePuzzleDisplay();
    }

    /// <summary> ��ʼ��ƴͼ���� </summary>
    void InitializePuzzle()
    {
        currentArray = (int[])solvedArray.Clone();
    }

    /// <summary> Fisher-Yatesϴ���㷨 </summary>
    void ShuffleArray(int shuffleTimes)
    {
        for (int i = 0; i < shuffleTimes; i++)
        {
            int r1 = Random.Range(0, currentArray.Length);
            int r2 = Random.Range(0, currentArray.Length);
            (currentArray[r1], currentArray[r2]) = (currentArray[r2], currentArray[r1]);
        }
    }

    /// <summary> ����ƴͼ��ʾ </summary>
    void UpdatePuzzleDisplay()
    {
        for (int i = 0; i < currentArray.Length; i++)
        {
            Transform piece = table.transform.Find($"piece{currentArray[i]}");
            piece.SetSiblingIndex(i);
        }
    }

    /// <summary> ͼ�����¼� </summary>
    public void OnPieceClick(int number)
    {
        if (number == 16) return; // �հ׿鲻�ɵ��

        int clickedIndex = GetPieceIndex(number);
        int blankIndex = GetBlankIndex();

        if (IsValidMove(clickedIndex, blankIndex))
        {
            SwapPieces(clickedIndex, blankIndex);
            CheckWinCondition();
        }
    }

    /// <summary> ��ȡͼ������ </summary>
    int GetPieceIndex(int number)
    {
        for (int i = 0; i < currentArray.Length; i++)
            if (currentArray[i] == number) return i;
        return -1;
    }

    /// <summary> ��ȡ�հ׿����� </summary>
    int GetBlankIndex()
    {
        return GetPieceIndex(16);
    }

    /// <summary> ��֤�ƶ���Ч�� </summary>
    bool IsValidMove(int clicked, int blank)
    {
        // ͬһ�����ڻ�ͬһ������
        return (Mathf.Abs(clicked - blank) == 1 && clicked / 4 == blank / 4) ||
               Mathf.Abs(clicked - blank) == 4;
    }

    /// <summary> ����ƴͼλ�� </summary>
    void SwapPieces(int indexA, int indexB)
    {
        (currentArray[indexA], currentArray[indexB]) = (currentArray[indexB], currentArray[indexA]);
        UpdatePuzzleDisplay();
    }

    /// <summary> ���ʤ������ </summary>
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