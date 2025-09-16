using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 按钮 : MonoBehaviour
{
    public GameObject boyButton;
    public GameObject girlButton;
    public GameObject playButton;
    public GameObject crowObject;

    void Start()
    {
        playButton.SetActive(false);
        crowObject.SetActive(false);
    }
}


