using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class LoadMain : MonoBehaviour
{
    public void LoadMainScene()
    {
        if (GameManager.Instance.charactor != null)
        {
            GameManager.instance.StopAllCoroutines();
            SceneManager.LoadScene("Main");
        }
    }

}
