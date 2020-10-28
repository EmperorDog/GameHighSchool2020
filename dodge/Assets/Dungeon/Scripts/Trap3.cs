using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trap3 : MonoBehaviour
{
    public UnityEvent m_OnExit;

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision이 어떤 Collision과 충돌이 끝났을 때");
        if (collision.rigidbody != null)
        {
            var player = collision.rigidbody
                .GetComponent<PlayerController_Dungeon2>();
            if (player != null)
                m_OnExit.Invoke();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision이 어떤 Collision과 충돌이 일어나고 있는 도중 때");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.rigidbody != null)
        //{
        //    var player = collision.rigidbody
        //        .GetComponent<PlayerController_Dungeon2>();
        //    if (player != null)
        //        player.Die();
        //}

        Debug.Log("Collision이 어떤 Collision과 충돌이 일어 났을 때");
    }



}
