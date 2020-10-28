using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable] public class TakeDamageEvent : UnityEvent<float> {}

public class HPConponent : MonoBehaviour
{
    public float m_MaxHp = 1;
    public float m_Hp;

    public TakeDamageEvent m_OnTakeDamage;
    public UnityEvent m_OnDie;

    public void OnEnable()
    {
        Revive();
    }

    public void Revive()
    {
        m_Hp = m_MaxHp;
    }

    public void TakeDamage(float damage)
    {
        m_Hp -= damage;

        if (m_Hp <= 0)
        {
            //사망
            m_OnDie.Invoke();
        }
        else
        {
            //데미지 처리
            m_OnTakeDamage.Invoke(damage);
        }
    }
}
