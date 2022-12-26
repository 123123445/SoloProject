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
    public bool isDie = false;
    bool leftMove;
    bool rightMove;
    bool lockleft = false;
    bool lockright = false;
    [SerializeField] private bool isCanJump = true;


    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    public Animator animator;
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
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }

        GameManager.instance.mainCharactor = gameObject;
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
                animator.SetBool("Main", true);
            }
            else if (spriteRenderer.sprite.name == "Owlet_Monster_0")
            {
                animator.runtimeAnimatorController = animatorList[1];
                animator.SetBool("Main", true);
            }
            else
            {
                animator.runtimeAnimatorController = animatorList[2];
                animator.SetBool("Main", true);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isDie)
        {
            if (leftMove && !lockleft)
            {
                transform.position = transform.position + new Vector3(-1, 0) * Time.deltaTime * speed;
            }
            else if (rightMove && !lockright)
            {
                transform.position = transform.position + new Vector3(1, 0) * Time.deltaTime * speed;
            }
        }
    }

    private void Update()
    {
        Hit();
    }

    #region move
    public void Jump()
    {
        if (isCanJump && !isDie)
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

    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isCanJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LockLeft")
        {
            lockleft = true;
        }
        else if (collision.gameObject.name == "LockRight")
        {
            lockright = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LockLeft")
        {
            lockleft = false;
        }
        else if (collision.gameObject.name == "LockRight")
        {
            lockright = false;
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
        if(nowHp <= 0 && !isDie)
        {
            animator.SetTrigger("Die");
            isDie = true;
            GameManager.instance.speed = 0f;
            StartCoroutine("GameOver");
        }
    }

    IEnumerator HitColor()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameOver");
        gameObject.SetActive(false);
    }
}
