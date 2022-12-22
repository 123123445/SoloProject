using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Arrow : MonoBehaviour
{
    public int speed;
    public RectTransform startPos;
    public RectTransform endPos;

    public List<Transform> CharactorPos = new List<Transform>();

    RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        
    }

    void MoveArrow()
    {
        rect.anchoredPosition = Vector3.Lerp(new Vector3(rect.anchoredPosition.x, startPos.anchoredPosition.y), new Vector3(rect.anchoredPosition.x, endPos.anchoredPosition.y), Mathf.PingPong(Time.time * speed, 1));
    }

    void Update()
    {
        if (GameManager.instance.Arrow == null)
        {
            GameManager.instance.Arrow = gameObject;
        }
        MoveArrow();

        if (GameManager.instance.charactor != null)
        {
            if (GameManager.instance.charactor.name == "Pink") //캐릭터별로 스프라이트 가져오기
            {
                transform.position = new Vector3(CharactorPos[0].position.x,transform.position.y);
            }
            else if (GameManager.instance.charactor.name == "Owlet")
            {
                transform.position = new Vector3(CharactorPos[1].position.x, transform.position.y);
            }
            else if (GameManager.instance.charactor.name == "Dude")
            {
                transform.position = new Vector3(CharactorPos[2].position.x, transform.position.y);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        endPos.anchoredPosition = (Vector3)startPos.anchoredPosition + new Vector3(0, 50, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        endPos = startPos;
    }

}
