using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharactor : MonoBehaviour
{
    public int nowHp;
    public int maxHp;

    float h;
    public float speed;
    public float jumpPower;
    [SerializeField] private bool isCanJump = true;

    bool leftMove;
    bool rightMove;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public List<RuntimeAnimatorController> animatorList = new List<RuntimeAnimatorController>();

    private void Awake()
    {
        nowHp = maxHp;
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
        KeyJump();
        if (leftMove)
        {
            transform.position = transform.position + new Vector3(-1, 0) * Time.deltaTime * speed;
            animator.SetInteger("isMove", -1);
            spriteRenderer.flipX = true; ;
        }else if (rightMove)
        {
            transform.position = transform.position + new Vector3(1, 0) * Time.deltaTime * speed;
            animator.SetInteger("isMove", 1);
            spriteRenderer.flipX = false;
        }
        else
        {
            animator.SetInteger("isMove", 0);
        }
    }

    public void Jump()
    {
        if (isCanJump)
        {
            rigid.AddForce(Vector3.up * jumpPower);
            animator.SetTrigger("Jump");
            isCanJump= false;
        }
    }

    public void LeftMoveDown()
    {
        leftMove = true;
    }

    public void LeftMoveUp()
    {
        leftMove = false;
    }

    public void RightMoveDown()
    {
        rightMove = true;
    }

    public void RightMoveUp()
    {
        rightMove = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isCanJump = true;
        }
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal");

        transform.position = transform.position + new Vector3(h, 0, 0) * Time.deltaTime * speed;
    }

    void KeyJump()
    {
        if (isCanJump && Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector3.up * jumpPower);
            animator.SetTrigger("Jump");
            isCanJump = false;
        }
    }
}
