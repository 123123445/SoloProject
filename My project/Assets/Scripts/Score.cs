using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public float _score;
    public float speed;
    TextMeshProUGUI text;

    private void Awake()
    {
        text= GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _score += 2 * speed;
        text.text = _score.ToString("N0");
    }

}
