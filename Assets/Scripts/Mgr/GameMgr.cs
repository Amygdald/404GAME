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
            SceneManager.LoadScene(nextScene);
        }
    }
    public void SetAArrive(bool arrive)
    {
        aArrive = arrive;
    }
    public void SetBArrive(bool arrive)
    {
        bArrive = arrive;
    }
    public void RestartGame()
    {
        // string name = SceneManager.GetActiveScene().name;
        // SceneManager.UnloadSceneAsync(name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        // GameObject.Find("Grid").transform.rotation = Quaternion.identity;
        // GameObject.Find("PlayerA").transform.position = new Vector3(3.3f, -12.9f, 0);
        // GameObject.Find("PlayerB").transform.position = new Vector3(0.7f, -12.6f, 0);


    }
}
