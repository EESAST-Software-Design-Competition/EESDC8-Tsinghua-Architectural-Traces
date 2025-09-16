using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class 视频交叉淡入淡出 : MonoBehaviour
{
    public RawImage rawImage1; // 第一个视频的 RawImage
    public RawImage rawImage2; // 第二个视频的 RawImage
    public float fadeDuration = 1f; // 淡入淡出时间

    private bool isTransitioning = false; // 是否正在过渡

    // 切换到下一个视频
    public void SwitchToNextVideo()
    {
        if (!isTransitioning)
        {
            StartCoroutine(CrossFadeVideos());
        }
    }

    // 交叉淡入淡出过渡
    private IEnumerator CrossFadeVideos()
    {
        isTransitioning = true;

        // 获取 CanvasGroup 组件
        CanvasGroup canvasGroup1 = rawImage1.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroup2 = rawImage2.GetComponent<CanvasGroup>();

        if (canvasGroup1 == null) canvasGroup1 = rawImage1.gameObject.AddComponent<CanvasGroup>();
        if (canvasGroup2 == null) canvasGroup2 = rawImage2.gameObject.AddComponent<CanvasGroup>();

        // 显示下一个视频
        rawImage2.gameObject.SetActive(true);

        // 同时淡出当前视频和淡入下一个视频
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup1.alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            canvasGroup2.alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup1.alpha = 0;
        canvasGroup2.alpha = 1;

        // 隐藏当前视频
        rawImage1.gameObject.SetActive(false);

        isTransitioning = false;
    }
}