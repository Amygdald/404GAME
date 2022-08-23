using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

<<<<<<< Updated upstream
public class MainPanelMgr : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Obj_HeatA;
    public GameObject Obj_HeatB;
    public GameObject Obj_HeatA_Bar;
    public GameObject Obj_HeatB_Bar;
    public GameObject Obj_HP;
    public GameObject Obj_Fuel;
    public GameObject Obj_State;
    public GameObject Obj_Icecream1;
    public GameObject Obj_Icecream2;
    public GameObject Obj_Icecream3;

    public float HeatA;
    public float HeatB;
    public float HP;

    public int Fuel;

    public string State;
    public int Icecream;
    public bool HeatA_Is_Hot;
    public bool HeatB_Is_Hot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Slider Slider_HeatA = this.Obj_HeatA.GetComponent<Slider>();
        Slider Slider_HeatB = this.Obj_HeatB.GetComponent<Slider>();
        Slider Slider_HP = this.Obj_HP.GetComponent<Slider>();
        Slider_HeatA.value = HeatA;
        Slider_HeatB.value = HeatB;
        Slider_HP.value = HP;
        TextMeshProUGUI Fuel_Text = this.Obj_Fuel.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI State_Text = this.Obj_State.GetComponent<TextMeshProUGUI>();
        Fuel_Text.text = (Fuel.ToString());
        State_Text.text = State;
        Image Icecream1_Image = this.Obj_Icecream1.GetComponent<Image>();
        Image Icecream2_Image = this.Obj_Icecream2.GetComponent<Image>();
        Image Icecream3_Image = this.Obj_Icecream3.GetComponent<Image>();
        Icecream1_Image.enabled = (Icecream >= 1);
        Icecream2_Image.enabled = (Icecream >= 2);
        Icecream3_Image.enabled = (Icecream >= 3);
        Animator AnimA = this.Obj_HeatA_Bar.GetComponent<Animator>();
        AnimA.Play(HeatA_Is_Hot ? "hot" : "heat");
        Animator AnimB = this.Obj_HeatB_Bar.GetComponent<Animator>();
        AnimB.Play(HeatB_Is_Hot ? "hot" : "heat");
    }
=======
public class MainPanelMgr : MonoSingleton<MainPanelMgr>
{
    public Transform iceTrans;
    public GameObject iceCream;
    public Slider aHeatSlider;
    public Slider bHeatSlider;
    public TextMeshProUGUI aState;
    public Slider bHpSlider;

    public Animator aHeatAnimator;
    public Animator bHeatAnimator;
    

  



>>>>>>> Stashed changes
}
