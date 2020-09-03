using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemComponent : MonoBehaviour
{
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public UnityEvent m_BeAteEvent;

    public virtual void Pickup()
    {
        m_BeAteEvent.Invoke();
    }
}

