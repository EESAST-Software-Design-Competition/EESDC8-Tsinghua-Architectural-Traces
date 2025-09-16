using UnityEngine;

public class 碰撞检测 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private bool canMove = true; // 是否允许移动

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (canMove)
        {
            // 获取输入
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // 计算移动方向
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            // 应用移动
            rb.velocity = movement * moveSpeed;
        }
        else
        {
            // 如果不允许移动，停止速度
            rb.velocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 检测是否碰到空气墙
        if (collision.gameObject.CompareTag("空气墙"))
        {
            // 禁止移动
            canMove = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // 检测是否离开空气墙
        if (collision.gameObject.CompareTag("空气墙"))
        {
            // 允许移动
            canMove = true;
        }
    }
}