using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorImage : MonoBehaviour
{
    Image charactor;

    private void Awake()
    {
        charactor = GetComponent<Image>();
    }

    private void Update()
    {
        charactor.sprite = GameManager.instance.sprite;
    }
}
