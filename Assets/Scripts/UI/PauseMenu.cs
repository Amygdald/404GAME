using UnityEngine.UI;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Button reStart;
    public Button returnToStart;
    private void Awake()
    {
        reStart.onClick.AddListener(()=>{
            GameMgr.instance.RestartGame();
        });
        returnToStart.onClick.AddListener(()=>{
            GameMgr.instance.SwitchLevel("Start");
        });
    }
    public void ShowHide()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        if(gameObject.activeSelf)
        {
            GameMgr.instance.SwitchPause(true);
        }
        else
        {
            GameMgr.instance.SwitchPause(false);
        }
    }



}
