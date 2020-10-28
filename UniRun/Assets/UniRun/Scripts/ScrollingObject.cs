using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float m_Speed = 1f;

    void Update()
    {
        transform.position += Vector3.left 
            * m_Speed * Time.deltaTime;
    }
}
