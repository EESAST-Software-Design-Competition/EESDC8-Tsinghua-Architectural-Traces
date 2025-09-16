using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 有进展面板出现 : MonoBehaviour
{
    [SerializeField] private 游戏进度 gameProgress;
    public bool isShow = false;
    private bool isfirst = true;
    public GameObject showPanel;
    // Start is called before the first frame update
   
    void OnMouseDown()
    {
        showPanel.SetActive(true);
        if (isfirst)
        {
            gameProgress.AdvanceProgress();
            isfirst = false;
        }
        isShow = true;
    }
}
