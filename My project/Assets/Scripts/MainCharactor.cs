using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharactor : MonoBehaviour
{
    float h;
    public float speed;
    public float jumpPower;
    [SerializeField] private bool isCanJump = true;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public List<RuntimeAnimatorController> animatorList = new List<RuntimeAnimatorController>();

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator= GetComponent<Animator>();
    }

    private void Start()
    {
        if (GameManager.instance.sprite != null)
        {
            spriteRenderer.sprite = GameManager.instance.sprite;
            if (spriteRenderer.sprite.name == "Pink_Monster_0")
            {
                animator.runtimeAnimatorController = animatorList[0];
            }
            else if (spriteRenderer.sprite.name == "Owlet_Monster_0")
            {
                animator.runtimeAnimatorController = animatorList[1];
            }
            else
            {
                animator.runtimeAnimatorController = animatorList[2];
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        transform.position = transform.position + new Vector3(h, 0) * Time.deltaTime * speed;
        animator.SetInteger("isMove", (int)h);
        if(h < 0)
        {
            spriteRenderer.flipX = true; ;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        Jump();
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {

            rigid.AddForce(Vector3.up * jumpPower);
        }
    }
}
