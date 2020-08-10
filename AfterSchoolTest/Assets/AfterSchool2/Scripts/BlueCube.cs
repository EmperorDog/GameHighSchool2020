using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCube : MonoBehaviour
{

    public float m_Speed = 5;

    void Update()
    {
        var movement = Vector3.down * m_Speed * Time.deltaTime;
        transform.position += movement;
    }

    public void OnPointerDownEvent()
    {
        GameManager.Instance.DamageLife();
        Destroy(gameObject);
        //클릭시 데미지
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "plane")
        {
            GameManager.Instance.AddScore();
            Destroy(gameObject);
            //바닥에 점수
        }
    }
}
