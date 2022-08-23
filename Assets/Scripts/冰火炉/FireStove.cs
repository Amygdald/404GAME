using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStove : MonoBehaviour
{

   
    public bool isOpen = false;
    public float temperatureMax = 60;
    public float temperatureMin = 30;
    public float temperatureAddRate = 1f;
    public Color openColor;

    private void Start()
    {
        if (isOpen)
        {
            GetComponent<SpriteRenderer>().color = openColor;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isOpen) return;
     
        PlayerA a = other.GetComponent<PlayerA>();
        if (a)
        {
            Debug.Log("设置");
            a.SetTemperature(temperatureAddRate, temperatureMax, temperatureMin);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!isOpen) return;
        
        PlayerA a = other.GetComponent<PlayerA>();
        if (a)
        {
            a.SetTemperature(0, temperatureMax, 0);
        }
    }
    public void SetState(bool open)
    {
        isOpen = open;
        if (open)
        {
            GetComponent<SpriteRenderer>().color = openColor;
        }
    }
}
