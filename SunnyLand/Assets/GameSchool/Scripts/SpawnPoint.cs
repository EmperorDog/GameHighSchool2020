using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject m_MonsterPrefab;
    public GameObject m_MonsterInstance;

    public bool m_IsStayPlayer;
    public float m_SpawnTimer = 5f;

    public void Update()
    {
        if (m_IsStayPlayer)
        {
            m_SpawnTimer += Time.deltaTime;
            if(m_SpawnTimer >= 5f)
            {
                //if(m_MonsterInstance == null)
                //{
                //    //dfadsf
                //}
                SpawnMonster();

                m_SpawnTimer = 0;
            }
        }
        else
        {
            m_SpawnTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.attachedRigidbody.tag == "Player")
        {
            //if(m_MonsterInstance == null)
            //{
            //    //dfadsf
            //}
            SpawnMonster();

            m_IsStayPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.tag == "Player")
        {
            m_IsStayPlayer = false;
        }
    }
//아래 추가 
    public Vector3 m_PatrolOffset;
    private void SpawnMonster()
    {
        if (m_MonsterInstance == null)
        {
            m_MonsterInstance =
                GameObject.Instantiate(m_MonsterPrefab,
                transform.position, transform.rotation);

            var flyPatrol = m_MonsterInstance
                .GetComponent<FlyPatrol>();
            
            flyPatrol.m_PatrolOffset = m_PatrolOffset;
            flyPatrol.ResetPatrolPos();
        }
    }
}
