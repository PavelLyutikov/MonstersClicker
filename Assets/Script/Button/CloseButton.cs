using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseButton : MonoBehaviour
{

    public void CloseGame()
    {
        SceneManager.LoadScene(1);
        DifficultyIncrease.time = 0;
        ClickCount.Click = 0;
    }
}
