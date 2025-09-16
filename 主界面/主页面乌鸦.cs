using UnityEngine;
using UnityEngine.SceneManagement;

public class 主页面乌鸦 : MonoBehaviour
{
    private Animator animator;
    

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayFlyAnimation()
    {
        animator.SetTrigger("FLY"); // 触发Fly参数
        
    }

   
}