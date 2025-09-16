// CharacterSelector.cs
using UnityEngine;
using UnityEngine.UI;

public class 角色选择 : MonoBehaviour
{
    // 绑定UI元素（通过Unity编辑器拖拽赋值）
    public GameObject boyButton;
    public GameObject girlButton;
    public GameObject playButton;
    public GameObject crow;

    void Start()
    {
        // 初始化时隐藏Play和乌鸦
        playButton.SetActive(false);
        crow.SetActive(false);
    }

    // 选择角色的公共方法（由按钮调用）
    public void SelectCharacter(string characterType)
    {
        // 1. 隐藏选择按钮
        boyButton.SetActive(false);
        girlButton.SetActive(false);

        // 2. 显示Play和乌鸦
        playButton.SetActive(true);
        crow.SetActive(true);

        // 3. 保存角色选择到PlayerPrefs
        PlayerPrefs.SetString("SelectedCharacter", characterType);
        PlayerPrefs.Save(); // 确保数据保存
    }

    // 跳转到游戏场景1

}