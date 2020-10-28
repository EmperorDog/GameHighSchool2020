using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator m_Animator;
    public Rigidbody2D m_Rigidbody2D;
    public AudioSource m_AudioSource;

    public AudioClip m_Jump;
    public AudioClip m_Die;

    public bool m_IsGround = false;
    public bool m_IsDead = false;

    public int m_JumpCount = 0;

    void Update()
    {
        if (m_IsDead) return;

        m_Animator.SetBool("IsGround", m_IsGround);

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    public void Jump()
    {
        if (m_JumpCount < 2)
        {
            m_Rigidbody2D.velocity
                = Vector2.zero;
            m_Rigidbody2D.AddForce(Vector2.up * 400);
            m_JumpCount++;

            m_AudioSource.clip = m_Jump;
            m_AudioSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.collider.tag == "Ground")
       {
            m_JumpCount = 0;
            m_IsGround = true;
       }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            m_IsGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone")
        {
            m_IsDead = true;
            m_Animator.SetBool("IsDead", m_IsDead);

            GameManager.Instance.OnPlayerDead();

            m_AudioSource.clip = m_Die;
            m_AudioSource.Play();
        }
    }
}
