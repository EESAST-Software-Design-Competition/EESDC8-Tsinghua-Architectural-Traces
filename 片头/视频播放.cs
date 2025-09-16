using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class 视频播放 : MonoBehaviour
{
    public RawImage rawImage1; // 第一个视频的 RawImage
    public RawImage rawImage2; // 第二个视频的 RawImage
    public RawImage rawImage3; // 第三个视频的 RawImage
    public RawImage rawImage4;
    public VideoPlayer videoPlayer1; // 第一个视频播放器
    public VideoPlayer videoPlayer2; // 第二个视频播放器
    public VideoPlayer videoPlayer3; // 第三个视频播放器
    public VideoPlayer videoPlayer4;
    public Button continueButton; // 继续按钮
    public string gameSceneName = "GameScene1"; // 游戏场景名称

    private int currentVideoIndex = 0; // 当前播放的视频索引

    void Start()
    {
        // 初始化
        rawImage1.gameObject.SetActive(false);
        rawImage2.gameObject.SetActive(false);
        rawImage3.gameObject.SetActive(false);
        rawImage4.gameObject.SetActive(false);
        // 绑定按钮点击事件
        continueButton.onClick.AddListener(OnContinueButtonClicked);
    }

    // 继续按钮点击事件
    private void OnContinueButtonClicked()
    {
        PlayNextVideo();
    }

    // 播放下一个视频
    private void PlayNextVideo()
    {
        // 隐藏当前视频
        switch (currentVideoIndex)
        {
            case 1:
                videoPlayer1.Stop();
                rawImage1.gameObject.SetActive(false);
                break;
            case 2:
                videoPlayer2.Stop();
                rawImage2.gameObject.SetActive(false);
                break;
            case 3:
                videoPlayer3.Stop();
                rawImage3.gameObject.SetActive(false);
                break;
            case 4:
                videoPlayer4.Stop();
                rawImage4.gameObject.SetActive(false);
                break;
        }

        // 更新索引
        currentVideoIndex++;

        // 播放下一个视频
        switch (currentVideoIndex)
        {
            case 1:
                rawImage1.gameObject.SetActive(true);
                videoPlayer1.Play();
                break;
            case 2:
                rawImage2.gameObject.SetActive(true);
                videoPlayer2.Play();
                break;
            case 3:
                rawImage3.gameObject.SetActive(true);
                videoPlayer3.Play();
                break;
            case 4:
                rawImage4.gameObject.SetActive(true);
                videoPlayer4.Play();
                break;
            default:
                // 所有视频已播放完毕，跳转到游戏场景
                SceneManager.LoadScene(gameSceneName);
                break;
        }
    }
}