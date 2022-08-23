using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(BoxCollider2D))]
public class Trigger : MonoBehaviour
{
    public string playerName="PlayerB";
    public UnityEvent onTriggerIn;
    public UnityEvent onTriggerOut;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name==playerName)
        {
            onTriggerIn?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.name == playerName)
        {
            onTriggerOut?.Invoke();
        }
    }
}
