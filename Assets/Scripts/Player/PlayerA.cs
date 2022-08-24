using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerA : PlayerBase
{
    public float iceJumpSpeed;
    public float waterJumpSpeed = 300;
    public AnimatorOverrideController iceAnim;
    public AnimatorOverrideController waterAnim;
    public AnimatorOverrideController airAnim;
    [Header("形态转换临界点")]
    public float waterIceTemperature = 0;
    public float waterAirTemperature = 20;

    public LayerMask playerMask;
    private AState state;


    void Start()
    {
        if (temperature > waterAirTemperature)
        {
            state = AState.空气;
            animator.runtimeAnimatorController = airAnim;
            MainPanelMgr.instance.aHeatAnimator.Play("hot");
        }
        else if (temperature >= waterIceTemperature)
        {
            state = AState.水;
            animator.runtimeAnimatorController = waterAnim;
            jumpSpeed = waterJumpSpeed;
            MainPanelMgr.instance.aHeatAnimator.Play("cold");
        }
        else
        {
            state = AState.冰块;
            animator.runtimeAnimatorController = iceAnim;
            jumpSpeed = iceJumpSpeed;
            MainPanelMgr.instance.aHeatAnimator.Play("cold");
        }
    }
    void Update()
    {
        if (!playerControl) return;
        UpdateTemperature();
        hor = Input.GetAxisRaw("HorizontalB");
        jump = Input.GetKeyDown(KeyCode.UpArrow);
        Jump();
        StateSwitch();


    }
    void FixedUpdate()
    {
        if (!playerControl) return;
        Movement();

    }

    private void StateSwitch()
    {
        if (state == AState.冰块)
        {
            if (temperature >= waterIceTemperature)
            {
                StartCoroutine(IceToWater());
                MainPanelMgr.instance.aHeatAnimator.Play("cold");
            }

        }
        else if (state == AState.水)
        {
            if (temperature < waterIceTemperature)
            {
                StartCoroutine(WaterToIce());
                MainPanelMgr.instance.aHeatAnimator.Play("cold");
            }
            else if (temperature > waterAirTemperature)
            {
                StartCoroutine(WaterToAir());
                MainPanelMgr.instance.aHeatAnimator.Play("hot");
            }

        }
        else if (state == AState.空气)
        {
            if (temperature < waterAirTemperature)
            {
                StartCoroutine(AirToWater());
                MainPanelMgr.instance.aHeatAnimator.Play("cold");
            }
        }
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
        //if (state == AState.air || boxCollider.IsTouchingLayers(playerMask)) return;
        if (state == AState.空气) return;
        if (Mathf.Abs(rb.velocity.y) < 0.1f)
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
        MainPanelMgr.instance.aHeatSlider.value = temperature;
        MainPanelMgr.instance.aState.text = "当前状态:" + state.ToString();
    }

    private IEnumerator IceToWater()
    {
        rb.velocity = new Vector2(0, 0);
        //失去控制
        playerControl = false;
        //切换动画
        animator.SetTrigger("icetowater");
        //修改状态
        state = AState.水;
        //等待动画结束
        yield return new WaitForSeconds(1.4f);
        //改变动画控制器
        animator.runtimeAnimatorController = waterAnim;
        animator.Play("Idle");
        yield return new WaitForSeconds(0.3f);
        //改变碰撞器
        boxCollider.size = spriteRenderer.sprite.bounds.size;
        boxCollider.offset = spriteRenderer.sprite.bounds.center;
        //修改跳跃速度
        jumpSpeed = waterJumpSpeed;
        //恢复控制
        playerControl = true;
    }
    private IEnumerator WaterToIce()
    {
        // //失去控制
        // playerControl = false;
        //切换动画
        animator.SetTrigger("watertoice");
        //修改状态
        state = AState.冰块;
        //等待动画结束
        yield return new WaitForSeconds(1.5f);
        //改变动画控制器
        animator.runtimeAnimatorController = iceAnim;
        animator.Play("Idle");
        yield return new WaitForSeconds(0.2f);
        //改变碰撞器
        boxCollider.size = spriteRenderer.sprite.bounds.size;
        boxCollider.offset = spriteRenderer.sprite.bounds.center;
        //修改跳跃速度
        jumpSpeed = iceJumpSpeed;
        // //恢复控制
        // playerControl = true;
    }
    private IEnumerator WaterToAir()
    {
        rb.velocity = new Vector2(0, 0);
        //失去控制
        // playerControl = false;
        //切换动画
        animator.SetTrigger("watertoair");
        //修改状态
        state = AState.空气;
        //等待动画结束
        yield return new WaitForSeconds(1.5f);
        //改变动画控制器
        animator.runtimeAnimatorController = airAnim;
        animator.Play("Idle");
        yield return new WaitForSeconds(0.2f);
        //改变碰撞器
        boxCollider.size = spriteRenderer.sprite.bounds.size;
        boxCollider.offset = spriteRenderer.sprite.bounds.center;
        //重力
        rb.gravityScale = -1;
        //恢复控制
        // playerControl = true;
    }
    private IEnumerator AirToWater()
    {
        rb.velocity = new Vector2(0, 0);
        //失去控制
        playerControl = false;
        //切换动画
        animator.SetTrigger("airtowater");
        //修改状态
        state = AState.水;
        //等待动画结束
        yield return new WaitForSeconds(2f);
        //位置
        transform.position = transform.position + Vector3.down * 1.4f;
        //改变动画控制器
        animator.runtimeAnimatorController = waterAnim;
        animator.Play("Idle");
        yield return new WaitForSeconds(0.2f);
        //改变碰撞器
        boxCollider.size = spriteRenderer.sprite.bounds.size;
        boxCollider.offset = spriteRenderer.sprite.bounds.center;
        //重力
        rb.gravityScale = 3;
        //恢复控制
        playerControl = true;
    }
    public void PassTube(Vector3 pos)
    {
        if (state == AState.水 || state == AState.空气)
        {
            StartCoroutine("PassTubeReal", pos);
        }
    }

    private IEnumerator PassTubeReal(Vector3 pos)
    {
        Transform gridTF = FindObjectOfType<Grid>().transform;
        transform.parent = gridTF;
        playerControl = false;
        rb.velocity = new Vector2(0, 0);
        var render = GetComponent<SpriteRenderer>();
        render.enabled = false;
        yield return new WaitForSeconds(0.4f);

        transform.localPosition = pos;

        transform.parent = null;
        playerControl = true;

        render.enabled = true;
    }

}
