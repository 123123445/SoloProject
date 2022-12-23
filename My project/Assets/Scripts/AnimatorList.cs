using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorList : MonoBehaviour
{
    public List<Animator> animatorList = new List<Animator>();

    public void Awake()
    {
        GameManager.instance.controller = animatorList;
    }
}
