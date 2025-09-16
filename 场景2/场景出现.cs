using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 场景出现 : MonoBehaviour

    //只出现场景1，其余先隐藏
{
    // Start is called before the first frame update
    public GameObject scene1, scene2, scene3, scene4;
    
    
    
    void Start()
    {
        scene2.SetActive(false);
        scene3.SetActive(false);
        scene4.SetActive(false);
    }

    // Update is called once per frame
    
}
