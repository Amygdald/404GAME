using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMgr : MonoSingleton<GameMgr>
{
    public string nextScene;
    [HideInInspector]
    public bool aArrive = false;
    [HideInInspector]
    public bool bArrive = false;
    private void Update()
    {
        if (aArrive && bArrive)
        {
            //到达下一关
            SceneManager.LoadScene(nextScene);
        }
    }
    //切换暂停继续
    public void SwitchPause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    //----设置A和B的是否到达
    public void SetAArrive(bool arrive)
    {
        aArrive = arrive;
    }
    public void SetBArrive(bool arrive)
    {
        bArrive = arrive;
    }
    //重启本关
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    //切换关卡
    public void SwitchLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
}
