using UnityEngine.UI;

using UnityEngine;

public class PlayerB : PlayerBase
{
    public float hp = 100;
    public LayerMask playerMask;
    public LayerMask groundMask;
    [HideInInspector]
    protected CircleCollider2D circleCollider;
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        if (!playerControl) return;
        UpdateTemperature();
        hor = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKeyDown(KeyCode.W);
        Jump();
    }
    void FixedUpdate()
    {
        if (!playerControl) return;
        Movement();

    }

    private void Movement()
    {
        rb.velocity = new Vector2(hor * speed * Time.fixedDeltaTime, rb.velocity.y);
        animator.SetFloat("move", hor);
        if (hor != 0)
        {
            transform.localScale = new Vector2(-hor, 1);
        }
    }
    private void Jump()
    {
        if (circleCollider.IsTouchingLayers(groundMask) || boxCollider.IsTouchingLayers(playerMask))
        {
            if (jump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * Time.fixedDeltaTime);
                animator.SetBool("jump", true);
            }
            else
                animator.SetBool("jump", false);
        }
    }
    protected override void UpdateTemperature()
    {
        base.UpdateTemperature();
        MainPanelMgr.instance.bHeatSlider.value = temperature;
        MainPanelMgr.instance.bHpSlider.value = hp;
    }
    public void UpdateHp()
    {
        if (temperature < 34 || temperature > 37)
        {
            hp = Mathf.MoveTowards(hp, 0, 10 * Time.deltaTime);
        }

        else
        {
            hp = Mathf.MoveTowards(hp, 100, 3 * Time.deltaTime);
        }
        hp = Mathf.Clamp(hp, 0, 100);
    }

}
