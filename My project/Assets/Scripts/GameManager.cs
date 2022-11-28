using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float speed;
    public float maxSpeed;

    Vector3 mousePosition;

    public Sprite sprite; //ĳ���� ��������Ʈ�� ���� ����Ʈ
    public GameObject charactor;

    public List<Sprite> spriteList = new List<Sprite>();

    #region Singleton
    public static GameManager instance = null;

    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameManager Instance
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

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "CharactorSelect")
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    //��ǥ ����
            if (Input.GetMouseButtonDown(0))
            {
                Ray2D ray = new Ray2D(mousePosition, Vector2.zero);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);    //���콺 ��ġ�� ���̹߻�
                if (hit)    //���̰� ���𰡸� �����ϸ�
                {
                    charactor = hit.transform.gameObject;

                    if (hit.transform.gameObject.name == "Pink") //ĳ���ͺ��� ��������Ʈ ��������
                    {
                        sprite = spriteList[0];
                    }
                    else if (hit.transform.gameObject.name == "Owlet")
                    {
                        sprite = spriteList[1];
                    }
                    else if (hit.transform.gameObject.name == "Dude")
                    {
                        sprite = spriteList[2];
                    }
                }
            }
        }
        else
        {
            if(!MainCharactor.instance.isDie)
                PlayTime();
        }
    }

 
    public void PlayTime()
    {
        if (speed <= maxSpeed)
        {
            speed += Time.deltaTime * 0.1f;
        }
        else
        {
            speed = maxSpeed;
        }
    }
}
