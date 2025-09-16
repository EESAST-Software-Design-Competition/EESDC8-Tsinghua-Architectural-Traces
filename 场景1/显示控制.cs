using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 需要添加UI命名空间

public class 显示控制 : MonoBehaviour
{
    public GameObject 华容道;
    public GameObject 信件;
    public Button 华容道退出; // 修正中文分号为英文分号

    void Start()
    {
        华容道.SetActive(false);
        信件.SetActive(false);

        // 添加按钮点击监听
        华容道退出.onClick.AddListener(CloseMainPanel);
    }

    void OnMouseDown()
    {
        if (!华容道.activeSelf)
        {
            ShowPanel();
        }
    }

    void ShowPanel()
    {
        华容道.SetActive(true);
        // 如果不需要按钮状态更新可以移除下面这行
        UpdateButtonStates();
    }

    void CloseMainPanel()
    {
        华容道.SetActive(false);
    }

    // 添加缺失的方法
    void UpdateButtonStates()
    {
        // 这里可以添加按钮状态更新逻辑
        // 例如：根据游戏状态禁用/启用按钮
    }

    // 移除了空的Update方法
}