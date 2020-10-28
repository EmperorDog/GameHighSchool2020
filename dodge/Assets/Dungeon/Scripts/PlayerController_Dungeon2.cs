using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Dungeon2 : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    public float m_Speed = 10f;

    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(xAxis, 0, zAxis).normalized * m_Speed;
        //리지드 바디를 이용한 이동 처리
        velocity.y = m_Rigidbody.velocity.y;
        m_Rigidbody.velocity = velocity;

        //transform을 이용한 이동 처리
        //Vector3 movement = velocity * Time.deltaTime;
        //transform.position = transform.position + movement;

        //transform.position; //월드 위치 좌표
        //transform.rotation; //월드 회전값
        //transform.lossyScale;   //월드 스케일값
        //transform.localPosition; // 부모에 자신의 위치정보
        //transform.localRotation; // 부모에 자신의 회전정보 
        //transform.localScale;     // 부모에 자신의 크기 정보

    }

    public void Die()
    {
        GameManager_Dungeon2 gameManager = FindObjectOfType<GameManager_Dungeon2>();
        gameManager.ReturnToStartPoint();
    }
}
