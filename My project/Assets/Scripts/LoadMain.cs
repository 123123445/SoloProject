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
            SceneManager.LoadScene("Main");
        }
    }

}
