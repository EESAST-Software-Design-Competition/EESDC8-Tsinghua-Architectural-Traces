using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 角色显示 : MonoBehaviour
{
    public GameObject boy; // 绑定男孩对象
    public GameObject girl; // 绑定女孩对象

    void Start()
    {
        // 从 PlayerPrefs 读取选择的角色类型，默认值为 "Girl"
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter", "Girl");

        // 根据选择显示对应的角色
        if (selectedCharacter == "Boy")
        {
            boy.SetActive(true);
            girl.SetActive(false);
        }
        else if (selectedCharacter == "Girl")
        {
            boy.SetActive(false);
            girl.SetActive(true);
        }
        else
        {
            Debug.LogError("未知的角色选择！");
        }
    }
}
