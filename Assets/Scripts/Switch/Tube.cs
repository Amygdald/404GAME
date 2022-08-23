using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    public Vector3 tarPos;
    public KeyCode key = KeyCode.Keypad0;
    private bool hasPeople = false;
    public string playerName = "PlayerA";

    void Update()
    {
        if (hasPeople)
        {
            if (Input.GetKeyDown(key))
            {
                FindObjectOfType<PlayerA>().PassTube(tarPos);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == playerName)
        {
            hasPeople = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == playerName)
        {
            hasPeople = false;
        }
    }

}
