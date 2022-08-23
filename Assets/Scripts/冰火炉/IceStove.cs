using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceStove : MonoBehaviour
{

    public bool isOpen = false;
    public float temperatureMax = -1;
    public float temperatureMin = -20;
    public float temperatureAddRate = -1f;
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
            a.SetTemperature(temperatureAddRate, temperatureMax, temperatureMin);
        }
        PlayerB b = other.GetComponent<PlayerB>();
        if (b)
        {
            b.SetTemperature(30);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!isOpen) return;
        PlayerA a = other.GetComponent<PlayerA>();
        if (a)
        {
            a.SetTemperature(0, 60, temperatureMin);
        }
        PlayerB b = other.GetComponent<PlayerB>();
        if (b)
        {
            b.SetTemperature(36);
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
