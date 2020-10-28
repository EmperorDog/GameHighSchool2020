using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySmall : MonoBehaviour
{
    public float m_Speed = 3f ;

    public Bullet m_Bullet;

    public Transform[] m_FireMulzzles;

    public float m_AttackDelay = 3f;
    public float m_AttackCooldown = 0f;

    public bool isDead = false;

    void Update()
    {
        //이동
        Vector3 velocity = transform.up * m_Speed;
        Vector3 movement = velocity * Time.deltaTime;
        transform.position += movement;

        if (!isDead && m_AttackCooldown <= 0)
        {
            //총알 발사
            foreach (var fireMulzzles in m_FireMulzzles)
            {
                GameObject.Instantiate(m_Bullet, fireMulzzles.position, fireMulzzles.rotation);
                m_AttackCooldown = m_AttackDelay;
            }
        }
        m_AttackCooldown -= Time.deltaTime;
    }


    public Animator m_Animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet")
        {
            m_Animator.SetBool("Die", true);

            GameManager.instance.AddScore();
            isDead = true;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
