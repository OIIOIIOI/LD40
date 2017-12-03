using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public float time;
    public Image clock;

    private void Update()
    {
        time -= Time.deltaTime;
        clock.fillAmount -= 1.0f / time * Time.deltaTime;

        if (clock.fillAmount <= 0f)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("TimeOutTransition");
    }
}
