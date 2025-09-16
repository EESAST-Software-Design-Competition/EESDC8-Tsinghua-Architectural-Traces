// TileTrigger.cs
using UnityEngine;

public class 进度控制 : MonoBehaviour
{
    [Header("触发设置")]
    public GameObject show;
    public GameObject hide1; // 拖入要显示的预制件
    public GameObject hide2;
    public GameObject hide3;


    void OnTriggerEnter(Collider other) // 3D 版本
    {
        if (other.CompareTag("Player"))
        {
            ShowObject();
        }
    }

    void Start()
    {
        show.SetActive(false);
        hide1.SetActive(false);
        hide2.SetActive(false);
        hide3.SetActive(false);
    }



    void ShowObject()
    {
        hide1.SetActive(false);
        hide2.SetActive(false);
        hide3.SetActive(false);
        show.SetActive(true);

    }
}