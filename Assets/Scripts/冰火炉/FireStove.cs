using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStove : MonoBehaviour
{


    public bool isOpen = false;

    public float temperatureAddRate = 2f;
    public Color openColor;

    private void Start()
    {
        if (isOpen)
        {
            GetComponent<SpriteRenderer>().color = openColor;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isOpen) return;

        PlayerA a = other.GetComponent<PlayerA>();
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
