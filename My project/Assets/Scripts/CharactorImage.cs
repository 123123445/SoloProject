using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorImage : MonoBehaviour
{
    Image image;

    private void Awake()
    {
        image= GetComponent<Image>();
    }

    void Update()
    {
        image.sprite = GameManager.Instance.sprite;
    }
}
