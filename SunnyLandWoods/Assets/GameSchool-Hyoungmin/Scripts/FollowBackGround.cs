using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBackGround : MonoBehaviour
{
    public float m_Grid = 20f;

    public GameObject[] m_Background;
    public Transform m_Target;

    public int m_OldMod = 0;

    public void Update()
    {
        int mod = Mathf.RoundToInt(m_Target.position.x / m_Grid);

        if(m_OldMod != mod)
        {
            foreach (var background in m_Background)
            {
                var pos = background.transform.position;
                pos.x += m_Grid * mod;
                background.transform.position = pos;
            }
        }
    }
}
