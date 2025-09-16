using UnityEngine;
using UnityEngine.SceneManagement;

public class 乌鸦动态转换 : MonoBehaviour
{
    private Animator animator;
    public float delayBeforeLoad = 1f; // 延迟时间

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayFlyAnimation()
    {
        animator.SetTrigger("FLY"); // 触发Fly参数
        Invoke("LoadGameScene", delayBeforeLoad); // 延迟加载场景
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("片头"); // 切换到游戏场景
    }
}