using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    public GameObject m_SpawnObject;
    
    public void Spawn()
    {
        GameObject.Instantiate(m_SpawnObject, transform.position, transform.rotation);
    }
}
