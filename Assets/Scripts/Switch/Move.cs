using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 startPos;
    public Vector3 endPos;
    public float speed = 5;
    private void Start()
    {
        startPos = transform.localPosition;
    }
    public void MoveToTarget(bool toEnd = true)
    {
        if (toEnd)
        {
            StartCoroutine("MoveReal", endPos);
        }
        else
        {
            StartCoroutine("MoveReal", startPos);
        }

    }
    public IEnumerator MoveReal(Vector3 tar)
    {
        while (transform.localPosition != tar)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, tar, speed * Time.deltaTime);
            yield return null;
        }
    }
    public void SetEndPos()
    {
        endPos = transform.position;
    }
}
