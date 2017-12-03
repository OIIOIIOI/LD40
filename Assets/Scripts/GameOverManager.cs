using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public float time;

    private void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0f)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("TimeOutTransition");
    }
}
