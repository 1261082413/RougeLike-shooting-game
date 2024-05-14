using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject gameUI;  // 在Inspector中设置你的UI预设

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            ShowGameUI();
        }
    }

    void ShowGameUI()
    {
        if (gameUI != null)
        {
            Instantiate(gameUI, Vector3.zero, Quaternion.identity);
        }
    }
}
