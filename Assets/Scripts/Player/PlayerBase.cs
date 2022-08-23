using UnityEngine.UI;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    protected bool playerControl = true;
    public float speed;
    public float jumpSpeed;
    public float temperature = 0;
    public float normalTemperature = 0;
    public float temperatureMax = 0;
    public float temperatureMin = 0;
    public float temperatureAddRate;
    protected Slider slider_Heat;

    protected Rigidbody2D rb;
    protected Animator animator;
    protected BoxCollider2D boxCollider;
    
    protected SpriteRenderer spriteRenderer;
    protected float hor;
    protected bool jump;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
       
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetPlayerControl(bool control)
    {
        playerControl = control;
    }

}
