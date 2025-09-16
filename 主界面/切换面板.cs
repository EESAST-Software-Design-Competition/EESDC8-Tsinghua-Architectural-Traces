using UnityEngine;
using System.Collections;

public class 切换面板 : MonoBehaviour
{
    public GameObject mainMenuPanel; // 主界面面板
    public GameObject settingsPanel; // 设置界面面板
    public GameObject characterSelectionPanel; // 人物选择界面面板

    void Start()
    {
        // 初始化界面状态
        ShowMainMenu();
    }

    // 显示主界面
    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        characterSelectionPanel.SetActive(false);
    }

    // 显示设置界面
    public void ShowSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        characterSelectionPanel.SetActive(false);
    }

    // 显示人物选择界面（带 2 秒延迟）
    public void ShowCharacterSelectionWithDelay()
    {
        StartCoroutine(ShowCharacterSelectionAfterDelay(1f));
    }

    // 协程：延迟 2 秒后显示人物选择界面
    private IEnumerator ShowCharacterSelectionAfterDelay(float delay)
    {
        // 等待 2 秒
        yield return new WaitForSeconds(delay);

        // 显示人物选择界面
        ShowCharacterSelection();
    }

    // 显示人物选择界面
    private void ShowCharacterSelection()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        characterSelectionPanel.SetActive(true);
    }
}