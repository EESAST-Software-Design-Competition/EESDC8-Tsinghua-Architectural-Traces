using UnityEngine;

public class 沿X轴移动 : MonoBehaviour
{
    public float moveDistance = 100f; // 移动的距离（单位：像素）
    public float moveSpeed = 1f; // 移动的速度

    private RectTransform rectTransform; // UI元素的RectTransform组件
    private Vector3 originalPosition; // UI元素的原始位置
    private float direction = 1f; // 移动方向（1 表示向右，-1 表示向左）

    void Start()
    {
        // 获取UI元素的RectTransform组件
        rectTransform = GetComponent<RectTransform>();
        // 记录UI元素的原始位置
        originalPosition = rectTransform.localPosition;
    }

    void Update()
    {
        // 计算当前的目标位置
        float targetX = originalPosition.x + moveDistance * direction;

        // 使用 Lerp 实现平滑移动
        rectTransform.localPosition = Vector3.Lerp(
            rectTransform.localPosition,
            new Vector3(targetX, originalPosition.y, originalPosition.z),
            moveSpeed * Time.deltaTime
        );

        // 如果接近目标位置，反转方向
        if (Mathf.Abs(rectTransform.localPosition.x - targetX) < 1f)
        {
            direction *= -1f; // 反转方向
        }
    }
}