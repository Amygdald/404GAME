using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceStove : MonoBehaviour
{

    public bool isOpen = false;
    public float temperatureAddRate = -2f;
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
        PlayerBase a = other.GetComponent<PlayerBase>();
        if (a)
        {
            a.SetTemperature(temperatureAddRate * Time.deltaTime);
        }

    }
    public void SetState(bool open)
    {
        isOpen = open;
        if (isOpen)
        {
            GetComponent<SpriteRenderer>().color = openColor;
        }
    }

}
