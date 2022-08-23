using UnityEngine.UI;

using UnityEngine;

public class PlayerB : PlayerBase
{
    public bool IsFrozen;
    public float hp = 100;
    public LayerMask playerMask;
    public LayerMask groundMask;
    [HideInInspector]
    protected CircleCollider2D circleCollider;
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        GameObject sliObj = GameObject.Find("Slider_Heat_Player2");
        if (sliObj)
        {
            slider_Heat = sliObj.GetComponent<Slider>();
        }
        else
            print("zhaobudao ");
    }
    void Update()
    {
        if (!playerControl) return;
        TemperatureChange();
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
        if (IsFrozen) return;
        rb.velocity = new Vector2(hor * speed * Time.fixedDeltaTime, rb.velocity.y);
        animator.SetFloat("move", hor);
        if (hor != 0)
        {
            transform.localScale = new Vector2(-hor, 1);
        }
    }
    private void Jump()
    {
<<<<<<< Updated upstream
        if (IsFrozen) return;
        if (rb.velocity.y == 0 || boxCollider.IsTouchingLayers(mask))
=======
        if (circleCollider.IsTouchingLayers(groundMask) || boxCollider.IsTouchingLayers(playerMask))
>>>>>>> Stashed changes
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
    private void TemperatureChange()
    {
        MainPanelMgr.instance.bHeatSlider.value = temperature;
        MainPanelMgr.instance.bHpSlider.value = hp;
        temperature = Mathf.MoveTowards(temperature, normalTemperature, 1f * Time.deltaTime);
        if (temperature < 34 || temperature > 37)
        {
            hp -= 3 * Time.deltaTime;
            hp = hp < 0 ? 0 : hp;
        }
        else
        {
            hp += 3 * Time.deltaTime;
            hp = hp > 100 ? 100 : hp;
        }

       
    }
    public void SetTemperature(float normal)
    {
        normalTemperature = normal;
    }

}
