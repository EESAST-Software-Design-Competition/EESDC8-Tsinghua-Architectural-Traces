using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 角色动画切换 : MonoBehaviour
{
    public Animator animator; // 动画控制器

    void Start()
    {
        // 获取 Animator 组件
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 获取输入
        float horizontal = Input.GetAxis("Horizontal"); // 左右方向
        float vertical = Input.GetAxis("Vertical"); // 上下方向

        // 判断是否有输入
        if (horizontal != 0 || vertical != 0)
        {
            // 按下方向键时，切换为奔跑动画
            animator.SetBool("IsRunning", true);
        }
        else
        {
            // 松开方向键时，切换为静止动画
            animator.SetBool("IsRunning", false);
        }
    }
}