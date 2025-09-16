using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class 答案检查 : MonoBehaviour
{
    // UI组件引用
    public GameObject panel;
    public InputField answerInput;
    public Button submitButton;
    public TMP_Text feedbackText;
    public string Answer;
    public GameObject 对话框;
    public GameObject 报纸;


    private void Start()
    {
        // 初始化组件

        对话框.SetActive(false);
        报纸.SetActive(false);
        feedbackText.text = "";
        submitButton.onClick.AddListener(CheckAnswer);
    }

    private void CheckAnswer()
    {
        string input = answerInput.text.Trim(); // 去除前后空格

       

        if (input == Answer)
        {
            ShowFeedback("回答正确！", Color.green);
            panel.SetActive(false);

            对话框.SetActive(true);
            报纸.SetActive(true);

        }
        else
        {
            ShowFeedback("答案错误，请重试！", Color.red);
        }
    }

    private void ShowFeedback(string message, Color color)
    {
        feedbackText.text = message;
        feedbackText.color = color;
    }
}