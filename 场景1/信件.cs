using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 信件 : MonoBehaviour
{
    public Button 信件退出;
    // Start is called before the first frame update
    public GameObject 信;
    public GameObject 展示;
    

    void Start()
    {
        信件退出.onClick.AddListener(ClosePanel);
    }

    void ClosePanel()
    {
        信.SetActive(false);
    }

    public void showPanel()
    {
        信.SetActive(false);
        展示.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
