using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class 文本出现控制 : MonoBehaviour
{
    [System.Serializable]
    public class Subtitle
    {
        public Text textComponent; // 直接引用 UI Text 组件
        public float startTime; // 字幕出现的时间点（秒）
        public float duration; // 字幕显示的持续时间（秒）
    }

    public Subtitle[] subtitles; // 字幕数组
    public RawImage rawImage; // 原始图像

    private float timer = 0f; // 计时器
    private int currentSubtitleIndex = 0; // 当前字幕索引
    private bool isShowingSubtitle = false; // 是否正在显示字幕

    void Start()
    {
        // 初始化
        foreach (var subtitle in subtitles)
        {
            if (subtitle.textComponent != null)
            {
                subtitle.textComponent.gameObject.SetActive(false); // 初始隐藏所有字幕
            }
        }
        rawImage.gameObject.SetActive(true); // 显示原始图像
    }

    void Update()
    {
        // 更新计时器
        timer += Time.deltaTime;

        // 检查是否需要显示字幕
        if (currentSubtitleIndex < subtitles.Length && timer >= subtitles[currentSubtitleIndex].startTime && !isShowingSubtitle)
        {
            // 显示当前字幕
            StartCoroutine(ShowSubtitle(currentSubtitleIndex));
        }
    }

    // 显示字幕并持续一段时间
    private IEnumerator ShowSubtitle(int index)
    {
        isShowingSubtitle = true;

        // 显示字幕
        if (subtitles[index].textComponent != null)
        {
            subtitles[index].textComponent.gameObject.SetActive(true);
        }

        // 等待字幕持续时间
        yield return new WaitForSeconds(subtitles[index].duration);

        // 隐藏字幕
        if (subtitles[index].textComponent != null)
        {
            subtitles[index].textComponent.gameObject.SetActive(false);
        }

        // 更新索引
        currentSubtitleIndex++;
        isShowingSubtitle = false;
    }
}