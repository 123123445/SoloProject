using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public void LoadCharactor()
    {
        SceneManager.LoadScene("CharactorSelect");
        MainCharactor.instance.gameObject.SetActive(true);
        MainCharactor.instance.nowHp = MainCharactor.instance.maxHp;

    }
}
