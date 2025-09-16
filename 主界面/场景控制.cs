using UnityEngine;
using UnityEngine.SceneManagement;

public class 场景控制 : MonoBehaviour
{
    public string secenName;
    public void LoadScene(string sceneName)
    {
        // 加载新场景，卸载当前场景
        SceneManager.LoadScene(sceneName);
    }
}