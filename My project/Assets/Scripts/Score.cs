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
    public TextMeshProUGUI text;

    #region Singleton

    public static Score instance = null;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

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

    public static Score Instance
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
        if (!MainCharactor.instance.isDie)
        {
            _score += 2 * speed;
            text.text = _score.ToString("N0");
        }
    }
}
