using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class 图片出现时间控制: MonoBehaviour
{
    public Image imageComponent; // 用于显示图片的 UI Image 组件
    public float startTime = 2f; // 图片出现的时间点（秒）
    public float duration = 3f; // 图片显示的持续时间（秒）

    private float timer = 0f; // 计时器
    private bool isImageShown = false; // 图片是否已显示

    void Start()
    {
        // 初始化
        if (imageComponent != null)
        {
            imageComponent.gameObject.SetActive(false); // 初始隐藏图片
        }
    }

    void Update()
    {
        // 更新计时器
        timer += Time.deltaTime;

        // 检查是否需要显示图片
        if (!isImageShown && timer >= startTime)
        {
            StartCoroutine(ShowImage());
        }
    }

    // 显示图片并持续一段时间
    private IEnumerator ShowImage()
    {
        isImageShown = true;

        // 显示图片
        if (imageComponent != null)
        {
            imageComponent.gameObject.SetActive(true);
        }

        // 等待图片显示的持续时间
        yield return new WaitForSeconds(duration);

        // 隐藏图片
        if (imageComponent != null)
        {
            imageComponent.gameObject.SetActive(false);
        }
    }
}