using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartMgr : MonoBehaviour
{
    public Button start;
    public Button exit;
    private void Awake()
    {
        start.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("teach");

        });
        exit.onClick.AddListener(() =>
        {
            Application.Quit();

        });

    }

}
