using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class 逐字打印 : MonoBehaviour
{
    public Text textComponent; // 用于显示文本的 UI Text 组件
    public string fullText = "这是逐字打印的文本效果。"; // 完整的文本内容
    public float delayBetweenChars = 0.1f; // 每个字符之间的延迟时间（秒）

    private bool isTyping = false; // 是否正在打印
    private Coroutine typingCoroutine; // 打印协程

    void Start()
    {
        // 启动逐字打印协程
        typingCoroutine = StartCoroutine(TypeText());
    }

    void Update()
    {
        // 如果玩家按下任意键，跳过打印
        if (isTyping && Input.anyKeyDown)
        {
            StopCoroutine(typingCoroutine);
            textComponent.text = fullText;
            isTyping = false;
        }
    }

    // 逐字打印协程
    private IEnumerator TypeText()
    {
        isTyping = true;

        // 清空初始文本
        textComponent.text = "";

        // 遍历完整文本的每个字符
        for (int i = 0; i < fullText.Length; i++)
        {
            // 将当前字符添加到文本组件
            textComponent.text += fullText[i];

            // 等待指定的延迟时间
            yield return new WaitForSeconds(delayBetweenChars);
        }

        isTyping = false;
    }
}