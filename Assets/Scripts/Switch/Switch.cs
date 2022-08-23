using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    
    private Vector3 originPos;
    public Vector3 endPos;
    public float speed = 5;
    private void Start()
    {
        originPos = transform.localPosition;

    }
    public void ToEndPos()
    {
        transform.localPosition = endPos;
    }
    public void ToStartPos()
    {
        transform.localPosition = originPos;
    }

}
