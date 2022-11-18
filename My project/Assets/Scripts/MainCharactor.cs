using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharactor : MonoBehaviour
{
    public int nowHp;
    public int maxHp;

    public float invincibilityTime;
    public float MaxInvincibilityTime = 1;

    public float speed;
    public float jumpPower;
    float h;

    public bool isCanHit = true;
    bool leftMove;
    bool rightMove;
    [SerializeField] private bool isCanJump = true;


    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public List<RuntimeAnimatorController> animatorList = new List<RuntimeAnimatorController>();


    #region Singleton
    public static MainCharactor instance = null;

    private void Awake()
    {
        nowHp = maxHp;
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static MainCharactor Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    #endregion

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
        }else if (rightMove)
        {
            transform.position = transform.position + new Vector3(1, 0) * Time.deltaTime * speed;
        }
    }

    private void Update()
    {
        Hit();
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

    public void Hit()
    {
        if (isCanHit == false)
        {
            StartCoroutine("HitColor");
            invincibilityTime += Time.deltaTime;
            if (invincibilityTime >= MaxInvincibilityTime)
            {
                invincibilityTime = 0;
                isCanHit = true;
            }
        }
        if(nowHp <= 0 && SceneManager.GetActiveScene().name == "Main")
        {
            SceneManager.LoadScene("GameOver");
            gameObject.SetActive(false);
        }
    }

    IEnumerator HitColor()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.5f);
    }
}
