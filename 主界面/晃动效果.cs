using UnityEngine;
using System.Collections;

public class 晃动效果 : MonoBehaviour
{
    public float maxShakeAmount = 2f; // 最大晃动幅度
    public float minShakeAmount = 0.5f; // 最小晃动幅度
    public float baseShakeSpeed = 0.3f; // 基础晃动速度
    public float windChangeInterval = 3f; // 风速变化间隔时间
    public float noiseScale = 0.05f; // 噪声缩放
    public Vector2 windDirection = new Vector2(1, 0.5f).normalized; // 风吹方向

    private RectTransform rectTransform; // UI元素的RectTransform组件
    private Vector3 originalPosition; // UI元素的原始位置
    private float noiseOffsetX, noiseOffsetY; // 用于生成噪声的偏移量
    private float currentShakeSpeed; // 当前晃动速度
    private float nextWindChangeTime; // 下一次风速变化的时间

    void Start()
    {
        // 获取UI元素的RectTransform组件
        rectTransform = GetComponent<RectTransform>();
        // 记录UI元素的原始位置
        originalPosition = rectTransform.localPosition;

        // 初始化噪声偏移量
        noiseOffsetX = Random.Range(0f, 100f);
        noiseOffsetY = Random.Range(0f, 100f);

        // 初始化风速和变化时间
        currentShakeSpeed = baseShakeSpeed;
        nextWindChangeTime = Time.time + windChangeInterval;

        // 启动持续晃动的协程
        StartCoroutine(WindShake());
    }

    // 持续风吹效果的协程
    private IEnumerator WindShake()
    {
        // 无限循环，确保UI元素持续晃动
        while (true)
        {
            // 检查是否需要改变风速
            if (Time.time >= nextWindChangeTime)
            {
                currentShakeSpeed = baseShakeSpeed * Random.Range(0.8f, 1.2f); // 随机调整速度
                nextWindChangeTime = Time.time + windChangeInterval;
            }

            // 使用 Perlin 噪声生成平滑的随机偏移量
            float offsetX = Mathf.PerlinNoise(noiseOffsetX, Time.time * currentShakeSpeed) * 2f - 1f;
            float offsetY = Mathf.PerlinNoise(noiseOffsetY, Time.time * currentShakeSpeed) * 2f - 1f;

            // 将噪声值缩放到晃动幅度范围内
            float currentShakeAmount = Random.Range(minShakeAmount, maxShakeAmount);
            offsetX *= currentShakeAmount * windDirection.x;
            offsetY *= currentShakeAmount * windDirection.y;

            // 更新UI元素的位置，使其晃动
            rectTransform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0);

            // 增加噪声偏移量，使晃动更加自然
            noiseOffsetX += noiseScale;
            noiseOffsetY += noiseScale;

            // 等待下一帧
            yield return null;
        }
    }
}