using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trap2 : MonoBehaviour
{
    public UnityEvent m_OnEnter;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("트리거 안에 어떤 Collider나 Trigger가 들어갔을 때");
        if(other.attachedRigidbody != null)
        {
            var player = other.attachedRigidbody
                .GetComponent<PlayerController_Dungeon2>();
            if (player != null)
                m_OnEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("트리거 안에 어떤 Collider나 Trigger가 나왔을 때");
        //스폰
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("트리거 안에 어떤 Collider나 Trigger가 들어가있는 도중");
    }

}
