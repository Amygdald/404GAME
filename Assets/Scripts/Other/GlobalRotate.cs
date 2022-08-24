using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalRotate : MonoBehaviour
{
    private PlayerBase playerA;
    private PlayerBase playerB;
    private Rigidbody2D aRb;
    private Rigidbody2D bRb;
    public float rotateSpeed;
    private bool isRoating = false;
    private void Awake()
    {
        playerA = FindObjectOfType<PlayerA>();
        playerB = FindObjectOfType<PlayerB>();
        aRb = playerA.GetComponent<Rigidbody2D>();
        bRb = playerB.GetComponent<Rigidbody2D>();
    }



    public void Rotate(float angle)
    {
        if (isRoating) return;

        StartCoroutine(RotateReal(angle));
    }
    private IEnumerator RotateReal(float angle)
    {
        isRoating = true;
        playerA.GetComponent<Animator>().enabled = false;
        playerB.GetComponent<Animator>().enabled = false;
        playerA.SetPlayerControl(false);
        playerB.SetPlayerControl(false);
        playerA.transform.parent = transform;
        playerB.transform.parent = transform;
        float aGravity = aRb.gravityScale;
        float bGravity = bRb.gravityScale;
        aRb.gravityScale = 0; aRb.velocity = new Vector2(0, 0);
        bRb.gravityScale = 0; bRb.velocity = new Vector2(0, 0);
        Quaternion tar = Quaternion.Euler(0, 0, angle) * transform.rotation;
        Quaternion tarA = Quaternion.Euler(0, 0, -angle) * playerA.transform.localRotation;
        Quaternion tarB = Quaternion.Euler(0, 0, -angle) * playerB.transform.localRotation;
        while (transform.localRotation != tar)
        {
            transform.localRotation = Quaternion.RotateTowards
                            (transform.localRotation, tar, rotateSpeed * Time.deltaTime);
            playerA.transform.localRotation = Quaternion.RotateTowards
                            (playerA.transform.localRotation, tarA, rotateSpeed * Time.deltaTime);
            playerB.transform.localRotation = Quaternion.RotateTowards
                            (playerB.transform.localRotation, tarB, rotateSpeed * Time.deltaTime);
            yield return null;
        }
        playerA.GetComponent<Animator>().enabled = true;
        playerB.GetComponent<Animator>().enabled = true;
        playerA.SetPlayerControl(true);
        playerB.SetPlayerControl(true);
        playerA.transform.parent = null;
        playerB.transform.parent = null;
        aRb.gravityScale = aGravity;
        bRb.gravityScale = bGravity;

        isRoating = false;
    }

}
