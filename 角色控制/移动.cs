using UnityEngine;

public class 移动 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int currentFace = 1;
    private bool facingRight = true;

    [Header("移动边界")]
    public float minX = -5f;
    public float maxX = 5f;
    public float minZ = -5f;
    public float maxZ = 5f;

    void Update()
    {
        // 原始输入逻辑（未调换左右）
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 保持面映射逻辑
        Vector3 movement = MapInputToFace(horizontal, vertical);

        // 移动角色
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // 新增位置限制
        ClampPosition();

        // 保持原有翻转逻辑
        HandleFlip(horizontal);
    }

    // 新增位置限制方法
    void ClampPosition()
    {
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, minX, maxX);
        clampedPos.z = Mathf.Clamp(clampedPos.z, minZ, maxZ);
        transform.position = clampedPos;
    }

    // 原有面映射逻辑保持不变
    Vector3 MapInputToFace(float horizontal, float vertical)
    {
        Vector3 movement = Vector3.zero;
        switch (currentFace)
        {
            case 1:
                movement = new Vector3(horizontal, 0, vertical);
                break;
            case 2:
                movement = new Vector3(-vertical, 0, horizontal);
                break;
            case 3:
                movement = new Vector3(horizontal, 0, -vertical);
                break;
            case 4:
                movement = new Vector3(-horizontal, 0, -vertical);
                break;
        }
        return movement;
    }

    // 原有翻转逻辑保持不变
    void HandleFlip(float horizontal)
    {
        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontal < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // 保持面切换方法
    public void ChangeFace(int newFace)
    {
        if (newFace >= 1 && newFace <= 4)
        {
            currentFace = newFace;
        }
    }

    // 调试边界可视化
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector3 center = new Vector3((minX + maxX) / 2, transform.position.y, (minZ + maxZ) / 2);
        Vector3 size = new Vector3(maxX - minX, 0.1f, maxZ - minZ);
        Gizmos.DrawWireCube(center, size);
    }
}