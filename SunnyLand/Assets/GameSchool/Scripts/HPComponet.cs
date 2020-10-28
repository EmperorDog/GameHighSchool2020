using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class HPComponet : MonoBehaviour
{
    public int m_HP = 10;

    public UnityEvent m_OnTakeDamage;

    public UnityEvent m_OnDie;
    //public UnityEvent m_OnTakeHeal;

    public virtual void TakeDamage(int damage)
    {
        m_OnTakeDamage.Invoke();

        m_HP -= damage;
        if(m_HP <= 0)
        {
            m_OnDie.Invoke();
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
