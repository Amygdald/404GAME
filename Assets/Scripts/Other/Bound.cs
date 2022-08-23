using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameMgr.instance.RestartGame();
        Debug.Log("重来");
    }
}
