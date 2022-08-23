using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerA : PlayerBase
{
<<<<<<< Updated upstream
    public bool IsFrozen;
    private float iceJumpSpeed;
=======
    public float iceJumpSpeed;
>>>>>>> Stashed changes
    public float waterJumpSpeed = 300;
    public AnimatorOverrideController iceAnim;
    public AnimatorOverrideController waterAnim;
    public AnimatorOverrideController airAnim;
    public LayerMask playerMask;
    private AState state;
    [HideInInspector]

    void Start()
    {
        if (temperature >= 100)
        {
            state = AState.air;
            animator.runtimeAnimatorController = airAnim;
            MainPanelMgr.instance.aHeatAnimator.Play("hot");
        }
        else if (temperature >= 0)
        {
            state = AState.water;
            animator.runtimeAnimatorController = waterAnim;
            jumpSpeed = waterJumpSpeed;
            MainPanelMgr.instance.aHeatAnimator.Play("heat");
        }
        else
        {
            state = AState.ice;
            animator.runtimeAnimatorController = iceAnim;
            jumpSpeed = iceJumpSpeed;
            MainPanelMgr.instance.aHeatAnimator.Play("heat");
        }



        // GameObject sliObj = GameObject.Find("Slider_Heat_Player1");
        // if (sliObj)
        // {
        //     slider_Heat = sliObj.GetComponent<Slider>(); print("找到了");
        // }
        // else
        //     print("zhaobudao ");
    }
    void Update()
    {
        if (!playerControl) return;
        TemperatureChange();
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
        if (state == AState.ice)
        {
            if (temperature >= 0)
            {
                StartCoroutine(IceToWater());
            }

        }
        else if (state == AState.water)
        {
            if (temperature < 0)
            {
                StartCoroutine(WaterToIce());
            }
            else if (temperature >= 100)
            {
                StartCoroutine(WaterToAir());
                MainPanelMgr.instance.aHeatAnimator.Play("hot");
            }

        }
        else if (state == AState.air)
        {
            if (temperature < 100)
            {
                StartCoroutine(AirToWater());
                MainPanelMgr.instance.aHeatAnimator.Play("heat");
            }
        }
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
        if (state == AState.air || boxCollider.IsTouchingLayers(mask)) return;
        if (rb.velocity.y == 0)
=======
        //if (state == AState.air || boxCollider.IsTouchingLayers(playerMask)) return;
        if (state == AState.air) return;
        if (Mathf.Abs(rb.velocity.y) < 0.1f)
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
    public void SetTemperature(float temperatureAddRate, float temperatureMax, float temperatureMin)
    {
        this.temperatureAddRate = temperatureAddRate;
        this.temperatureMax = temperatureMax;
        this.temperatureMin = temperatureMin;
    }
    private void TemperatureChange()
    {
        if (temperatureAddRate == 0)
        {
            temperature = Mathf.MoveTowards(temperature, normalTemperature, 2f * Time.deltaTime);

        }
        else
        {
            temperature += temperatureAddRate * Time.deltaTime;
            temperature = temperature > temperatureMax ? temperature : temperatureMax;
            temperature = temperature < temperatureMin ? temperature : temperatureMin;
        }
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
        state = AState.water;
        //等待动画结束
        yield return new WaitForSeconds(1.5f);
        //改变动画控制器
        animator.runtimeAnimatorController = waterAnim;
        animator.Play("Idle");
        yield return new WaitForSeconds(0.2f);
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
        state = AState.ice;
        yield return new WaitForSeconds(0.35f);
        // rb.velocity = new Vector2(0, 0);
        //等待动画结束
        yield return new WaitForSeconds(1.15f);
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
        state = AState.air;
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
        state = AState.water;
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
        if (state == AState.water || state == AState.air)
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
