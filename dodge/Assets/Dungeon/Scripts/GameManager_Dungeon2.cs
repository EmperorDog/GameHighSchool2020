using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Dungeon2 : MonoBehaviour
{
    public Transform m_StartPoint;
    public PlayerController_Dungeon2 m_Player;

    public Text m_ClearUI;
    public Text m_ScoreUI;

    public float m_Score = 0;
    public bool m_isPlaying = false;

    public void Start()
    {
        GameStart();
    }
    public void Update()
    {
        if (m_isPlaying)
        {
            m_Score += Time.deltaTime;
            m_ScoreUI.text = string.Format("Score : {0}", m_Score);
        }
    }

    public void GameStart()
    {
        m_isPlaying = true;

        //출발지점에서 플레이어가 스폰
        m_Player.gameObject.SetActive(true);
        m_Player.transform.position = m_StartPoint.position;
        m_Player.transform.rotation = m_StartPoint.rotation;
        //게임 클리어 메세지가 보이지 않는다.
        m_ClearUI.gameObject.SetActive(false);
        //게임 스코어 메시지가 보인다.
        m_ScoreUI.gameObject.SetActive(true);
    }

    public void GameClear()
    {
        m_isPlaying = false;

        //플레이어가 비활성화된다.
        m_Player.gameObject.SetActive(false);
        //게임 클리어 메세지가 보인다.
        m_ClearUI.gameObject.SetActive(true);
        //게임 스코어 메시지가 보인다.
        m_ScoreUI.gameObject.SetActive(true);

        //활성화된 적은 비활성화
        var enemisType1 = FindObjectsOfType<RotationBulletSpawner>();
        foreach (var enemy in enemisType1)
        {
            enemy.gameObject.SetActive(false);
        }

        var enemisType2 = FindObjectsOfType<BulletSpawner>();
        foreach (var enemy in enemisType2)
        {
            enemy.gameObject.SetActive(false);
        }

        //SetActivityAllGameObject(typeof(BulletSpawner), false);
        //SetActivityAllGameObject(typeof(RotationBulletSpawner), false);
        //탄환 삭제
        //총알 제거
        Bullet[] bullets = FindObjectsOfType<Bullet>();

        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject); //Destory(게임오브젝트) 게임오브젝트를 제거하는 기능 
        }

        //클리어 타임 빠른 1,2,3위를 저장 표시하기
        float num1 = PlayerPrefs.GetFloat("Num1", 999);
        float num2 = PlayerPrefs.GetFloat("Num2", 999);
        float num3 = PlayerPrefs.GetFloat("Num3", 999);

        if(m_Score < num1)
        {
            num3 = num2;
            num2 = num1;
            num1 = m_Score;
        }
        else if(m_Score < num2)
        {
            num3 = num2;
            num2 = m_Score;
        }
        else if (m_Score < num3)
        {
            num3 = m_Score;
        }

        PlayerPrefs.SetFloat("Num1", num1);
        PlayerPrefs.SetFloat("Num2", num2);
        PlayerPrefs.SetFloat("Num3", num3);
        PlayerPrefs.Save();

        m_ClearUI.text = string.Format("Game Claer\n 1위 : {0}, 2위 : {1}, 3위 : {2}", num1, num2, num3);
    }

    public void SetActivityAllGameObject(Type type, bool isActivity)
    {
        var objects = FindObjectsOfType(type);
        foreach (var obj in objects)
        {
            var monoBehaviour = (MonoBehaviour)obj;
            monoBehaviour.gameObject.SetActive(false);
        }
    }

    public void ReturnToStartPoint()
    {
        //플레이어를 출발지점으로 되돌린다.
        m_Player.transform.position = m_StartPoint.position;
        m_Player.transform.rotation = m_StartPoint.rotation;
    }
}
