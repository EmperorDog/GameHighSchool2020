using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UnityEngine.UI.Text m_ScoreUI;
    public int m_Score = 0;

    //싱글톤
    public static GameManager instance;
    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore()
    {
        m_Score += 10;
        m_ScoreUI.text = "Score : " + m_Score;
    }

    public bool m_IsGameOver;
    public void OnPlayerDie()
    {
        m_IsGameOver = true;
    }

    public void Update()
    {
        if(m_IsGameOver && Input.GetKeyDown(KeyCode.R))
        {
            //SceneManager.LoadScene(":evel_Main");
            SceneManager.LoadScene(0);
            //SceneManager.LoadScene("df/Level_Main");
        }
    }
}
