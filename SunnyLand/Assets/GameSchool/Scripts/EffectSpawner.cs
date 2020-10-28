using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    public GameObject m_EffectPrefab;
    public void SpawnEffect()
    {
        GameObject.Instantiate(m_EffectPrefab, 
         transform.position, transform.rotation);
    }

}
