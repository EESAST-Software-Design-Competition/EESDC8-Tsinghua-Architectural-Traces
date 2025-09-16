using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 面板出现 : MonoBehaviour
{
    public GameObject showPanel;
    public GameObject showPanel1;
    public GameObject 报纸;
    // Start is called before the first frame update
    void Start()
    {
        showPanel.SetActive(false);
        showPanel1.SetActive(false);
        报纸.SetActive(false);
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        showPanel.SetActive(true);
    }
}