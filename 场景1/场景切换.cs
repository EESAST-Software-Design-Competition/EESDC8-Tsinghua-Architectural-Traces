using UnityEngine;
using System.Collections;

public class 场景切换 : MonoBehaviour
{
    [Header("过渡参数")]
    [SerializeField] float transitionDuration = 2f;    // 场景切换时间
    [SerializeField] float fadeDuration = 0.5f;       // 淡入淡出时间

    [Header("摄像机控制")]
    [SerializeField] Camera mainCamera;              // 角色主摄像机
    [SerializeField] Camera transitionCamera;        // 过场摄像机

    [Header("场景控制")]
    [SerializeField] Transform sceneRoot;           // 3D场景父物体
    [SerializeField] Vector3[] scenePositions = new Vector3[4];  // 场景坐标
    [SerializeField] Vector3[] sceneRotations = new Vector3[4]; // 场景旋转

    [Header("角色控制")]
    [SerializeField] GameObject player3DContainer;  // 3D控制空物体
    [SerializeField] SpriteRenderer playerSprite;    // 2D角色精灵
    [SerializeField] Collider playerCollider;        // 3D碰撞体

    [Header("传送门控制")]
    [SerializeField] SpriteRenderer leftPortalSprite;  // 左侧传送门精灵
    [SerializeField] SpriteRenderer rightPortalSprite; // 右侧传送门精灵
    [SerializeField] Collider leftPortalCollider;      // 左侧传送门碰撞体
    [SerializeField] Collider rightPortalCollider;     // 右侧传送门碰撞体

    [Header("碰撞体保护")]
    [SerializeField] float collisionCooldown = 3f;  // 场景切换后碰撞体禁用时间

    private int currentSceneIndex = 0;
    private bool isTransitioning;
    private Color originalPlayerColor;
    private Color originalLeftPortalColor;
    private Color originalRightPortalColor;

    void Start()
    {
        mainCamera.enabled = true;
        transitionCamera.enabled = false;

        // 初始化颜色
        originalPlayerColor = playerSprite.color;
        originalLeftPortalColor = leftPortalSprite.color;
        originalRightPortalColor = rightPortalSprite.color;

        CheckReferences();
        InitializeScene();
    }

    void CheckReferences()
    {
        if (!sceneRoot || !player3DContainer)
            Debug.LogError("未正确分配场景或角色容器引用！");
    }

    void InitializeScene()
    {
        sceneRoot.position = scenePositions[currentSceneIndex];
        sceneRoot.rotation = Quaternion.Euler(sceneRotations[currentSceneIndex]);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) return;

        if (collision.gameObject.CompareTag("左侧空气墙"))
            StartCoroutine(TransitionProcess(-1));
        else if (collision.gameObject.CompareTag("右侧空气墙"))
            StartCoroutine(TransitionProcess(1));
    }

    IEnumerator TransitionProcess(int direction)
    {
        isTransitioning = true;

        // 禁用所有碰撞体
        SetCollidersState(false);

        // 切换摄像机
        SwitchCameras();

        // 淡出效果
        yield return StartCoroutine(FadeObjects(false));

        // 场景过渡
        yield return StartCoroutine(SceneTransition(direction));

        // 淡入效果
        yield return StartCoroutine(FadeObjects(true));

        // 在淡入完成后添加保护期等待
        yield return new WaitForSeconds(collisionCooldown);

        // 最后才启用碰撞体


        // 恢复状态
        SwitchCameras(true);
        SetCollidersState(true);
        isTransitioning = false;
    }

    IEnumerator SceneTransition(int direction)
    {
        Vector3 startPos = sceneRoot.position;
        Quaternion startRot = sceneRoot.rotation;
        int targetIndex = (currentSceneIndex + direction + 4) % 4;

        float elapsed = 0f;
        while (elapsed < transitionDuration)
        {
            float progress = elapsed / transitionDuration;
            sceneRoot.position = Vector3.Lerp(startPos, scenePositions[targetIndex], progress);
            sceneRoot.rotation = Quaternion.Slerp(startRot, Quaternion.Euler(sceneRotations[targetIndex]), progress);
            elapsed += Time.deltaTime;
            yield return null;
        }

        currentSceneIndex = targetIndex;
        sceneRoot.position = scenePositions[targetIndex];
        sceneRoot.rotation = Quaternion.Euler(sceneRotations[targetIndex]);
    }

    IEnumerator FadeObjects(bool fadeIn)
    {
        float startAlpha = fadeIn ? 0 : 1;
        float targetAlpha = fadeIn ? 1 : 0;

        SpriteRenderer[] renderers = {
            playerSprite,
            leftPortalSprite,
            rightPortalSprite
        };

        Color[] originalColors = {
            originalPlayerColor,
            originalLeftPortalColor,
            originalRightPortalColor
        };

        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, timer / fadeDuration);
            for (int i = 0; i < renderers.Length; i++)
            {
                if (renderers[i] != null)
                {
                    renderers[i].color = new Color(
                        originalColors[i].r,
                        originalColors[i].g,
                        originalColors[i].b,
                        alpha
                    );
                }
            }
            timer += Time.deltaTime;
            yield return null;
        }

        // 确保最终状态
        for (int i = 0; i < renderers.Length; i++)
        {
            if (renderers[i] != null)
            {
                renderers[i].color = new Color(
                    originalColors[i].r,
                    originalColors[i].g,
                    originalColors[i].b,
                    targetAlpha
                );
            }
        }
    }

    void SwitchCameras(bool restoreMain = false)
    {
        mainCamera.enabled = restoreMain;
        transitionCamera.enabled = !restoreMain;
    }

    void SetCollidersState(bool enabled)
    {
        playerCollider.enabled = enabled;
        leftPortalCollider.enabled = enabled;
        rightPortalCollider.enabled = enabled;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 30), $"当前场景索引: {currentSceneIndex}");
        GUI.Label(new Rect(10, 40, 300, 30), $"切换状态: {(isTransitioning ? "进行中" : "就绪")}");
    }
}