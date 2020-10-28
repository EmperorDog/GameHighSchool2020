using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] m_Obstacles;
    public bool m_IsTouch = false;

    private void OnEnable()
    {
        m_IsTouch = false;
        foreach (var obstacle in m_Obstacles)
        {
            obstacle.SetActive(false);

            if (Random.Range(0, 3) == 0)
                obstacle.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(m_IsTouch == false)
        {
            GameManager.Instance.OnAddScore();
            m_IsTouch = true;
        }
    }
}
