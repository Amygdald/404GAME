using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMgr : MonoBehaviour
{
    // Start is called before the first frame update
    // public int TimeinSec;
    // public GameObject Comment;
    // public GameObject TimeUsed;
    // public GameObject IceCream1;
    // public GameObject IceCream2;
    // public GameObject IceCream3;
    public string StartScene;
    public Button btn_continue;
    // int score;

    void Start()
    {
        btn_continue.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(StartScene);

        });
        // if (TimeinSec <= 240) score = 3;
        // else if (TimeinSec <= 420) score = 2;
        // else score = 1;

        // TextMeshProUGUI PingJia = this.Comment.GetComponent<TextMeshProUGUI>();
        // TextMeshProUGUI Shijian = this.TimeUsed.GetComponent<TextMeshProUGUI>();

        // Shijian.text = "��ʱ" + TimeinSec.ToString() + "S";

        // if (score == 3)
        // {
        //     PingJia.text = "����ѩ�⣬�����������ա�";
        // }

        // if (score == 2)
        // {
        //     PingJia.text = "����һ�㣬���˴��š�";
        //     Image Icecream3_Image = this.IceCream3.GetComponent<Image>();
        //     Icecream3_Image.enabled = false;
        // }

        // if (score == 1)
        // {
        //     PingJia.text = "Ҳ����һ�»��ܳԣ�";
        //     Image Icecream3_Image = this.IceCream3.GetComponent<Image>();
        //     Icecream3_Image.enabled = false;
        //     Image Icecream2_Image = this.IceCream2.GetComponent<Image>();
        //     Icecream2_Image.enabled = false;
        // }


    }

  
}
