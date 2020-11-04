using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger2D : MonoBehaviour
{
    [System.Flags]
    public enum Mask
    {
        None = 0,               //000000
        Player = ( 1 << 0 ),    //000001
        Enemy  = ( 1 << 1 ),    //000010
        Ect    = ( 1 << 2 ),    //000100
        Ground = ( 1 << 3 ),    //001000 //추가
        All = Player | Enemy,   //000011
    }

    public Mask m_Mask;

    public UnityEvent m_OnTriggerEnter;
    public UnityEvent m_OnTriggerStay;
    public UnityEvent m_OnTriggerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((m_Mask & Mask.Player) == Mask.Player)   //플러그 참일 경우 처리,
        {
            if (collision.attachedRigidbody != null 
                && collision.attachedRigidbody.tag == "Player")
                m_OnTriggerEnter.Invoke();
        }

        if((m_Mask & Mask.Enemy) == Mask.Enemy)
        {
            if (collision.attachedRigidbody != null
                && collision.attachedRigidbody.tag == "Enemy")
                m_OnTriggerEnter.Invoke();
        }

        if ((m_Mask & Mask.Ect) == Mask.Ect)
        {
            if (collision.attachedRigidbody != null
                && collision.attachedRigidbody.tag == "Ect")
                m_OnTriggerEnter.Invoke();
        }

        if ((m_Mask & Mask.Ground) == Mask.Ground)
        {
            if (collision.attachedRigidbody != null
                && collision.attachedRigidbody.tag == "Ground")
                m_OnTriggerEnter.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((m_Mask & Mask.Player) == Mask.Player)   //플러그 참일 경우 처리,
        {
            if (collision.attachedRigidbody != null
                && collision.attachedRigidbody.tag == "Player")
                m_OnTriggerStay.Invoke();
        }

        if ((m_Mask & Mask.Enemy) == Mask.Enemy)
        {
            if (collision.attachedRigidbody != null
                && collision.attachedRigidbody.tag == "Enemy")
                m_OnTriggerStay.Invoke();
        }

        if ((m_Mask & Mask.Ect) == Mask.Ect)
        {
            if (collision.attachedRigidbody != null
                && collision.attachedRigidbody.tag == "Ect")
                m_OnTriggerStay.Invoke();
        }

        if ((m_Mask & Mask.Ground) == Mask.Ground)
        {
            if (collision.attachedRigidbody != null
                && collision.attachedRigidbody.tag == "Ground")
                m_OnTriggerStay.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((m_Mask & Mask.Player) == Mask.Player)   //플러그 참일 경우 처리,
        {
            if (collision.attachedRigidbody != null
                && collision.attachedRigidbody.tag == "Player")
                m_OnTriggerExit.Invoke();
        }

        if ((m_Mask & Mask.Enemy) == Mask.Enemy)
        {
            if (collision.attachedRigidbody != null
                && collision.attachedRigidbody.tag == "Enemy")
                m_OnTriggerExit.Invoke();
        }

        if ((m_Mask & Mask.Ect) == Mask.Ect)
        {
            if (collision.attachedRigidbody != null
                && collision.attachedRigidbody.tag == "Ect")
                m_OnTriggerExit.Invoke();
        }

        if ((m_Mask & Mask.Ground) == Mask.Ground)
        {
            if (collision.attachedRigidbody != null
                && collision.attachedRigidbody.tag == "Ground")
                m_OnTriggerExit.Invoke();
        }
    }


}
