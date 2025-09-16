using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 跳过 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel1;
    public GameObject panel2;

    public void 跳过1()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
}
