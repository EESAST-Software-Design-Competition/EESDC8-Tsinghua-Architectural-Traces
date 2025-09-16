using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 展示 : MonoBehaviour
{
    [SerializeField] private 游戏进度 gameProgress;
    private bool isFirst1=true;
    // Start is called before the first frame update
    public GameObject close;
    public GameObject open;

    void Start()
    {
        open.SetActive(false);
    }

    public void closePanel()
    {
        close.SetActive(false);
        open.SetActive(true);
        if (isFirst1)
        {
            gameProgress.AdvanceProgress();
            isFirst1 = false;
        }
        
    }
}
